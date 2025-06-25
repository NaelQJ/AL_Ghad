using AutoMapper;
using AutoMapper.QueryableExtensions;
using Moe.Core.Models.DTOs;
using Moe.Core.Data;
using Moe.Core.Extensions;
using Moe.Core.Helpers;
using Moe.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Moe.Core.Services;

public interface ISponsorShipsService
{
	Task<Response<PagedList<SponsorShipDTO>>> GetAll(SponsorShipFilter filter);
	Task<Response<SponsorShipDTO>> GetById(Guid id);
	Task<Response<SponsorShipDTO>> Create(SponsorShipFormDTO form);
	Task Update(SponsorShipUpdateDTO update);
	Task Delete(Guid id);
}

public class SponsorShipsService : BaseService, ISponsorShipsService
{
	public SponsorShipsService(MasterDbContext context, IMapper mapper): base(context, mapper)
	{}

    public async Task<Response<PagedList<SponsorShipDTO>>> GetAll(SponsorShipFilter filter)
    {
        var sponsorShips = await _context.SponsorShips
            .Include(s => s.Sponsor)
            .Include(s => s.Orphan)
            .Include(s => s.Family)
            .WhereBaseFilter(filter)
            .OrderByCreationDate()
            .ProjectTo<SponsorShipDTO>(_mapper.ConfigurationProvider)
            .Paginate(filter);

        return new Response<PagedList<SponsorShipDTO>>(sponsorShips, null, 200);
    }


    public async Task<Response<SponsorShipDTO>> GetById(Guid id)
	{
        var dto = await _context.GetByIdOrException<SponsorShip, SponsorShipDTO>(id);
		return new Response<SponsorShipDTO>(dto, null, 200);
	}

	public async Task<Response<SponsorShipDTO>> Create(SponsorShipFormDTO form)
	{

	    var dto = await _context.CreateWithMapper<SponsorShip,SponsorShipDTO>(form, _mapper);

		return new Response<SponsorShipDTO>(dto, null, 200);
	}

	public async Task Update(SponsorShipUpdateDTO update)
	{
	    await _context.UpdateWithMapperOrException<SponsorShip,SponsorShipUpdateDTO>(update, _mapper);
	}

	public async Task Delete(Guid id) =>
	    await _context.SoftDeleteOrException<SponsorShip>(id);
}
