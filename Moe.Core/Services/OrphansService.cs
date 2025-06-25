using AutoMapper;
using AutoMapper.QueryableExtensions;
using Moe.Core.Models.DTOs;
using Moe.Core.Data;
using Moe.Core.Extensions;
using Moe.Core.Helpers;
using Moe.Core.Models.Entities;

namespace Moe.Core.Services;

public interface IOrphansService
{
    Task<Response<PagedList<OrphanDTO>>> GetAll(OrphanFilter filter);
    Task<Response<OrphanDTO>> GetById(Guid id);
    Task<Response<OrphanDTO>> Create(OrphanFormDTO form);
    Task Update(OrphanUpdateDTO update);
    Task Delete(Guid id);
}

public class OrphansService : BaseService, IOrphansService
{
    public OrphansService(MasterDbContext context, IMapper mapper) : base(context, mapper)
    { }

    public async Task<Response<PagedList<OrphanDTO>>> GetAll(OrphanFilter filter)
    {
        var orphans = await _context.Orphans
         .WhereBaseFilter(filter)
         .Where(e => string.IsNullOrWhiteSpace(filter.FullName) || e.FullName.Contains(filter.FullName))
         .Where(e => !filter.Birthday.HasValue || e.Birthday == filter.Birthday)
         .Where(e => !filter.Score.HasValue || e.Score == filter.Score)
         .Where(e => string.IsNullOrWhiteSpace(filter.Gender) || e.Gender == filter.Gender)
         .Where(e => !filter.FamilyId.HasValue || e.FamilyId == filter.FamilyId)

                 .OrderByCreationDate()
            .ProjectTo<OrphanDTO>(_mapper.ConfigurationProvider)
            .Paginate(filter);

        return new Response<PagedList<OrphanDTO>>(orphans, null, 200);
    }

    public async Task<Response<OrphanDTO>> GetById(Guid id)
    {
        var dto = await _context.GetByIdOrException<Orphan, OrphanDTO>(id);
        return new Response<OrphanDTO>(dto, null, 200);
    }

    public async Task<Response<OrphanDTO>> Create(OrphanFormDTO form)
    {
        await _context.EnsureEntityExists<Family>(form.FamilyId, "Family not found");
        var dto = await _context.CreateWithMapper<Orphan, OrphanDTO>(form, _mapper);
        return new Response<OrphanDTO>(dto, null, 200);
    }

    public async Task Update(OrphanUpdateDTO update)
    {
        await _context.UpdateWithMapperOrException<Orphan, OrphanUpdateDTO>(update, _mapper);
    }

    public async Task Delete(Guid id) =>
        await _context.SoftDeleteOrException<Orphan>(id);
}
