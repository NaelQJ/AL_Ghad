using AutoMapper;
using AutoMapper.QueryableExtensions;
using Moe.Core.Models.DTOs;
using Moe.Core.Data;
using Moe.Core.Extensions;
using Moe.Core.Helpers;
using Moe.Core.Models.Entities;

namespace Moe.Core.Services;

public interface ISponsorsService
{
    Task<Response<PagedList<SponsorSimplDTO>>> GetAll(SponsorFilter filter);
    Task<Response<SponsorDTO>> GetById(Guid id);
    Task<Response<SponsorSimplDTO>> Create(SponsorFormDTO form);
    Task Update(SponsorUpdateDTO update);
    Task Delete(Guid id);
}

public class SponsorsService : BaseService, ISponsorsService
{
    public SponsorsService(MasterDbContext context, IMapper mapper) : base(context, mapper)
    { }

    public async Task<Response<PagedList<SponsorSimplDTO>>> GetAll(SponsorFilter filter)
    {
        var sponsors = await _context.Sponsors
            .WhereBaseFilter(filter)
            .Where(e => filter.Status == null || e.Status == filter.Status)
            .Where(e => filter.PaymentMethod == null || e.PaymentMethod == filter.PaymentMethod)
            .Where(e => string.IsNullOrWhiteSpace(filter.FullName) || e.FullName.ToLower().Contains(filter.FullName.ToLower()))
            .Where(e => filter.OrphanCount == null || e.OrphanCount == filter.OrphanCount)
            .Where(e => filter.StartSpons == null || e.StartSpons == filter.StartSpons)
            .Where(e => string.IsNullOrWhiteSpace(filter.JobTitle) || e.JobTitle.ToLower().Contains(filter.JobTitle.ToLower()))
            .Where(e => string.IsNullOrWhiteSpace(filter.Address) || e.Address.ToLower().Contains(filter.Address.ToLower()))
            .OrderByCreationDate()
            .ProjectTo<SponsorSimplDTO>(_mapper.ConfigurationProvider)
            .Paginate(filter);

        return new Response<PagedList<SponsorSimplDTO>>(sponsors, null, 200);
    }

    public async Task<Response<SponsorDTO>> GetById(Guid id)
    {
        var dto = await _context.GetByIdOrException<Sponsor, SponsorDTO>(id);
        return new Response<SponsorDTO>(dto, null, 200);
    }

    public async Task<Response<SponsorSimplDTO>> Create(SponsorFormDTO form)
    {
        var dto = await _context.CreateWithMapper<Sponsor, SponsorSimplDTO>(form, _mapper);

        return new Response<SponsorSimplDTO>(dto, null, 200);
    }

    public async Task Update(SponsorUpdateDTO update)
    {
        await _context.UpdateWithMapperOrException<Sponsor, SponsorUpdateDTO>(update, _mapper);
    }

    public async Task Delete(Guid id) =>
        await _context.SoftDeleteOrException<Sponsor>(id);
}
