using AutoMapper;
using AutoMapper.QueryableExtensions;
using Moe.Core.Models.DTOs;
using Moe.Core.Data;
using Moe.Core.Extensions;
using Moe.Core.Helpers;
using Moe.Core.Models.Entities;

namespace Moe.Core.Services;

public interface IDevicesService
{
	Task<Response<PagedList<DeviceDTO>>> GetAll(DeviceFilter filter);
	Task<Response<DeviceDTO>> GetById(Guid id);
	Task<Response<DeviceDTO>> Create(DeviceFormDTO form);
	Task Update(DeviceUpdateDTO update);
	Task Delete(Guid id);
}

public class DevicesService : BaseService, IDevicesService
{
	public DevicesService(MasterDbContext context, IMapper mapper): base(context, mapper)
	{}

	public async Task<Response<PagedList<DeviceDTO>>> GetAll(DeviceFilter filter)
	{
		var devices = await _context.Devices
			.WhereBaseFilter(filter)
			.OrderByCreationDate()
			.ProjectTo<DeviceDTO>(_mapper.ConfigurationProvider)
			.Paginate(filter);

		return new Response<PagedList<DeviceDTO>>(devices, null, 200);
	}

	public async Task<Response<DeviceDTO>> GetById(Guid id)
	{
        var dto = await _context.GetByIdOrException<Device, DeviceDTO>(id);
		return new Response<DeviceDTO>(dto, null, 200);
	}

	public async Task<Response<DeviceDTO>> Create(DeviceFormDTO form)
	{
	    var dto = await _context.CreateWithMapper<Device,DeviceDTO>(form, _mapper);

		return new Response<DeviceDTO>(dto, null, 200);
	}

	public async Task Update(DeviceUpdateDTO update)
	{
	    await _context.UpdateWithMapperOrException<Device,DeviceUpdateDTO>(update, _mapper);
	}

	public async Task Delete(Guid id) =>
	    await _context.SoftDeleteOrException<Device>(id);
}
