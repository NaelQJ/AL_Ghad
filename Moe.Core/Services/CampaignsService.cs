using AutoMapper;
using AutoMapper.QueryableExtensions;
using Moe.Core.Models.DTOs;
using Moe.Core.Data;
using Moe.Core.Extensions;
using Moe.Core.Helpers;
using Moe.Core.Models.Entities;

namespace Moe.Core.Services;

public interface ICampaignsService
{
	Task<Response<PagedList<CampaignDTO>>> GetAll(CampaignFilter filter);
	Task<Response<CampaignDTO>> GetById(Guid id);
	Task<Response<CampaignDTO>> Create(CampaignFormDTO form);
	Task Update(CampaignUpdateDTO update);
	Task Delete(Guid id);
}

public class CampaignsService : BaseService, ICampaignsService
{
	public CampaignsService(MasterDbContext context, IMapper mapper): base(context, mapper)
	{}

    public async Task<Response<PagedList<CampaignDTO>>> GetAll(CampaignFilter filter)
    {
        var query = _context.Campaigns
            .WhereBaseFilter(filter)
            .Where(e => filter.Title == null || e.Title.ToLower().Contains(filter.Title.ToLower()))
            .Where(e => filter.Beneficiary == null || e.Beneficiary.ToLower().Contains(filter.Beneficiary.ToLower()))
            .Where(e => filter.StartDate == null || e.StartDate == filter.StartDate)
            .Where(e => filter.TargetAmount == null || e.TargetAmount == filter.TargetAmount)
            .Where(e => filter.Description == null || e.Description.ToLower().Contains(filter.Description.ToLower()))
            .Where(e => filter.Status == null || e.Status == filter.Status)
            .OrderByCreationDate();

        var campaigns = await query
            .ProjectTo<CampaignDTO>(_mapper.ConfigurationProvider)
            .Paginate(filter);

        return new Response<PagedList<CampaignDTO>>(campaigns, null, 200);
    }


    public async Task<Response<CampaignDTO>> GetById(Guid id)
	{
        var dto = await _context.GetByIdOrException<Campaign, CampaignDTO>(id);
		return new Response<CampaignDTO>(dto, null, 200);
	}

	public async Task<Response<CampaignDTO>> Create(CampaignFormDTO form)
	{
	    var dto = await _context.CreateWithMapper<Campaign,CampaignDTO>(form, _mapper);

		return new Response<CampaignDTO>(dto, null, 200);
	}

	public async Task Update(CampaignUpdateDTO update)
	{
	    await _context.UpdateWithMapperOrException<Campaign,CampaignUpdateDTO>(update, _mapper);
	}

	public async Task Delete(Guid id) =>
	    await _context.SoftDeleteOrException<Campaign>(id);
}
