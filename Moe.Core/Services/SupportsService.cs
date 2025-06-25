using AutoMapper;
using AutoMapper.QueryableExtensions;
using Moe.Core.Models.DTOs;
using Moe.Core.Data;
using Moe.Core.Extensions;
using Moe.Core.Helpers;
using Moe.Core.Models.Entities;

namespace Moe.Core.Services;

public interface ISupportsService
{
	Task<Response<PagedList<SupportDTO>>> GetAll(SupportFilter filter);
	Task<Response<SupportDTO>> GetById(Guid id);
	Task<Response<SupportDTO>> Create(SupportFormDTO form);
	Task Update(SupportUpdateDTO update);
	Task Delete(Guid id);
}

public class SupportsService : BaseService, ISupportsService
{
	public SupportsService(MasterDbContext context, IMapper mapper): base(context, mapper)
	{}

	public async Task<Response<PagedList<SupportDTO>>> GetAll(SupportFilter filter)
	{
		var supports = await _context.Supports
			.WhereBaseFilter(filter)
			.OrderByCreationDate()
			.ProjectTo<SupportDTO>(_mapper.ConfigurationProvider)
			.Paginate(filter);

		return new Response<PagedList<SupportDTO>>(supports, null, 200);
	}

	public async Task<Response<SupportDTO>> GetById(Guid id)
	{
        var dto = await _context.GetByIdOrException<Support, SupportDTO>(id);
		return new Response<SupportDTO>(dto, null, 200);
	}

	public async Task<Response<SupportDTO>> Create(SupportFormDTO form)
	{
	    var dto = await _context.CreateWithMapper<Support,SupportDTO>(form, _mapper);

		return new Response<SupportDTO>(dto, null, 200);
	}

	public async Task Update(SupportUpdateDTO update)
	{
	    await _context.UpdateWithMapperOrException<Support,SupportUpdateDTO>(update, _mapper);
	}

	public async Task Delete(Guid id) =>
	    await _context.SoftDeleteOrException<Support>(id);
}
