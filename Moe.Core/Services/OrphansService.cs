using AutoMapper;
using AutoMapper.QueryableExtensions;
using Moe.Core.Models.DTOs;
using Moe.Core.Data;
using Moe.Core.Extensions;
using Moe.Core.Helpers;
using Moe.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Moe.Core.Null;

namespace Moe.Core.Services;

public interface IOrphansService
{
    Task<Response<PagedList<OrphanSimplDTO>>> GetAll(OrphanFilter filter);
    Task<Response<OrphanDTO>> GetById(Guid id);
    Task<Response<OrphanSimplDTO>> Create(OrphanFormDTO form);
    Task Update(OrphanUpdateDTO update);
    Task Delete(Guid id);
}

public class OrphansService : BaseService, IOrphansService
{
    public OrphansService(MasterDbContext context, IMapper mapper) : base(context, mapper)
    { }

    public async Task<Response<PagedList<OrphanSimplDTO>>> GetAll(OrphanFilter filter)
    {
        var orphans = await _context.Orphans
         .WhereBaseFilter(filter)
         .Where(e => string.IsNullOrWhiteSpace(filter.FullName) || e.FullName.Contains(filter.FullName))
         .Where(e => !filter.Birthday.HasValue || e.Birthday == filter.Birthday)
         .Where(e => !filter.Score.HasValue || e.Score == filter.Score)
         .Where(e => string.IsNullOrWhiteSpace(filter.Gender) || e.Gender == filter.Gender)
         .Where(e => !filter.FamilyId.HasValue || e.FamilyId == filter.FamilyId)

                 .OrderByCreationDate()
            .ProjectTo<OrphanSimplDTO>(_mapper.ConfigurationProvider)
            .Paginate(filter);

        return new Response<PagedList<OrphanSimplDTO>>(orphans, null, 200);
    }

    public async Task<Response<OrphanDTO>> GetById(Guid id)
    {
        var Orphan = await _context.Orphans
            .Include(o => o.Documents)
        .FirstOrDefaultAsync(f => f.Id == id);

        if (Orphan == null)
            return new Response<OrphanDTO>(null, "Not Found", 404);

        var dto = _mapper.Map<OrphanDTO>(Orphan);
        return new Response<OrphanDTO>(dto, null, 200);
    }

    public async Task<Response<OrphanSimplDTO>> Create(OrphanFormDTO form)
    {
        await _context.EnsureEntityExists<Family>(form.FamilyId, "Family not found");
        var dto = await _context.CreateWithMapper<Orphan, OrphanSimplDTO>(form, _mapper);
        return new Response<OrphanSimplDTO>(dto, null, 200);
    }

    public async Task Update(OrphanUpdateDTO update)
    {
        await _context.UpdateWithMapperOrException<Orphan, OrphanUpdateDTO>(update, _mapper);

        var orphan = await _context.Orphans
            .Include(o => o.Documents)
            .FirstOrDefaultAsync(o => o.Id == update.Id);
        if (orphan == null)
            ErrResponseThrower.NotFound();

        if (update.Documents != null)
        {
            orphan.Documents.Clear();
            foreach (var file in update.Documents)
            {
                orphan.Documents.Add(new Document
                {
                    FilePath = file,
                    OrphanId = orphan.Id
                });
            }
        }
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id) =>
        await _context.SoftDeleteOrException<Orphan>(id);
}
