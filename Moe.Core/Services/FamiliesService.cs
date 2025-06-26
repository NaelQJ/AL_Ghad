using AutoMapper;
using AutoMapper.QueryableExtensions;
using Moe.Core.Models.DTOs;
using Moe.Core.Data;
using Moe.Core.Extensions;
using Moe.Core.Helpers;
using Moe.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Moe.Core.Models.DTOs.User;

namespace Moe.Core.Services;

public interface IFamiliesService
{
    Task<Response<PagedList<FamilySimpleDTO>>> GetAll(FamilyFilter filter);
    Task<Response<FamilyDTO>> GetById(Guid id);
    Task<Response<FamilySimpleDTO>> Create(FamilyFormDTO form);
    Task Update(FamilyUpdateDTO update);
    Task Delete(Guid id);
}

public class FamiliesService : BaseService, IFamiliesService
{
    public FamiliesService(MasterDbContext context, IMapper mapper) : base(context, mapper)
    { }

    public async Task<Response<PagedList<FamilySimpleDTO>>> GetAll(FamilyFilter filter)
    {

        var query = _context.Families
      .WhereBaseFilter(filter)
      .Where(e => string.IsNullOrWhiteSpace(filter.FatherName) || e.FatherName.Contains(filter.FatherName))
      .Where(e => string.IsNullOrWhiteSpace(filter.MotherName) || e.MotherName.Contains(filter.MotherName))
      .Where(e => filter.IsActive == null || e.IsActive == filter.IsActive);

        var families = await query
                .OrderByCreationDate()
                .ProjectTo<FamilySimpleDTO>(_mapper.ConfigurationProvider)
                .Paginate(filter);


        return new Response<PagedList<FamilySimpleDTO>>(families, null, 200);
    }

    public async Task<Response<FamilyDTO>> GetById(Guid id)
    {
        var dto = await _context.GetByIdOrException<Family, FamilyDTO>(id);
        return new Response<FamilyDTO>(dto, null, 200);
    }

    public async Task<Response<FamilySimpleDTO>> Create(FamilyFormDTO form)
    {
        var dto = await _context.CreateWithMapper<Family, FamilySimpleDTO>(form, _mapper);
        return new Response<FamilySimpleDTO>(dto, null, 200);
    }





    public async Task Update(FamilyUpdateDTO update)
    {
        await _context.UpdateWithMapperOrException<Family, FamilyUpdateDTO>(update, _mapper);
    }

    public async Task Delete(Guid id)
    {
        await _context.SoftDeleteOrException<Family>(id);

        var orphans = await _context.Orphans
      .Where(o => o.FamilyId == id)
      .ToListAsync();

        foreach (var orphan in orphans)
        {
            await _context.SoftDeleteOrException<Orphan>(orphan.Id);
        }
    }


}
