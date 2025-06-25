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
    Task<Response<PagedList<FamilyDTO>>> GetAll(FamilyFilter filter);
    Task<Response<FamilyDTO>> GetById(Guid id);
    Task<Response<FamilyDTO>> Create(FamilyFormDTO form);
    Task Update(FamilyUpdateDTO update);
    Task Delete(Guid id);
}

public class FamiliesService : BaseService, IFamiliesService
{
    public FamiliesService(MasterDbContext context, IMapper mapper) : base(context, mapper)
    { }

    public async Task<Response<PagedList<FamilyDTO>>> GetAll(FamilyFilter filter)
    {

        var query = _context.Families
      .WhereBaseFilter(filter)
      .Where(e => string.IsNullOrWhiteSpace(filter.FatherName) || e.FatherName.Contains(filter.FatherName))
      .Where(e => string.IsNullOrWhiteSpace(filter.MotherName) || e.MotherName.Contains(filter.MotherName))
      .Where(e => filter.Status == null || e.Status == filter.Status);

        var families = await query
                .OrderByCreationDate()
                .ProjectTo<FamilyDTO>(_mapper.ConfigurationProvider)
                .Paginate(filter);


        return new Response<PagedList<FamilyDTO>>(families, null, 200);
    }

    public async Task<Response<FamilyDTO>> GetById(Guid id)
    {
        var dto = await _context.GetByIdOrException<Family, FamilyDTO>(id);
        return new Response<FamilyDTO>(dto, null, 200);
    }

    public async Task<Response<FamilyDTO>> Create(FamilyFormDTO form)
    {
        // ????? FamilyFormDTO ??? Family ???????? AutoMapper
        var family = _mapper.Map<Family>(form);

        // ????? Documents ? Devices ???????? AutoMapper
        family.Documents = form.Documents?.Select(documentName => new Document { FilePath = documentName }).ToList();
        family.Devices = form.Devices?.Select(deviceName => new Device { DevicePath = deviceName }).ToList();

        // ??? ??????? ?? ????????? ???????? ?? ????? ????????
        _context.Families.Add(family);
        await _context.SaveChangesAsync();

        // ????? ??????? ??? FamilyDTO ???????? AutoMapper
        var dto = _mapper.Map<FamilyDTO>(family);

        // ????? ?????????
        return new Response<FamilyDTO>(dto, null, 200);
    }




    public async Task Update(FamilyUpdateDTO update)
    {

        await _context.UpdateWithMapperOrException<Family, FamilyUpdateDTO>(update, _mapper);
        if (update.OrphanIds?.Any() == true)
        {

            await _context.Orphans
                .Where(o => update.OrphanIds.Contains(o.Id))
                .ForEachAsync(o => o.FamilyId = update.Id);
            await _context.SaveChangesAsync();
        }

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
