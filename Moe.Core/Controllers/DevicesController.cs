using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moe.Core.Models.DTOs;
using Moe.Core.ActionFilters;
using Moe.Core.Helpers;
using Moe.Core.Models.DTOs;
using Moe.Core.Services;

namespace Moe.Core.Controllers;

/// <summary>
/// Basic cruds
/// </summary>
public class DevicesController : BaseController
{
	private readonly IDevicesService _devicesService;

	public DevicesController(IDevicesService devicesService)
	{
		_devicesService = devicesService;
	}
	
	#region CRUDs
    /// <summary>
    /// Retrieves a paged list
    /// </summary>
    /// <remarks>
    /// Required Roles: `Any`
    /// </remarks>
	[Authorize]
	[TypeFilter(typeof(SoftDeleteAccessFilterActionFilter))]
	[HttpGet]
	public async Task<ActionResult<Response<PagedList<DeviceDTO>>>> GetAll([FromQuery] DeviceFilter filter) =>
		Ok(await _devicesService.GetAll(filter));

    /// <summary>
    /// Retrieves a single instance by its ID
    /// </summary>
    /// <remarks>
    /// Required Roles: `Any`
    /// </remarks>
	[Authorize]
	[HttpGet("{id}")]
	public async Task<ActionResult<Response<DeviceDTO>>> GetById(Guid id) =>
		Ok(await _devicesService.GetById(id));

    /// <summary>
    /// Creates a new instance
    /// </summary>
    /// <remarks>
    /// Required Roles: `Any`
    /// </remarks>
	[Authorize]
	[HttpPost]
	public async Task<ActionResult<Response<DeviceDTO>>> Create([Required] [FromBody] DeviceFormDTO form) =>
		Ok(await _devicesService.Create(form));

    /// <summary>
    /// Updates an instance determined by its ID
    /// </summary>
    /// <remarks>
    /// Required Roles: `Any`
    /// </remarks>
	[Authorize]
	[HttpPut("{id}")]
	[ProducesResponseType(204)]
	[ProducesResponseType(404)]
	public async Task<IActionResult> Update([Required] [FromBody] DeviceUpdateDTO update, Guid id)
	{
		update.Id = id;
		await _devicesService.Update(update);
		
		return Ok();
	}

    /// <summary>
    /// Deletes an instance determined by its ID
    /// </summary>
    /// <remarks>
    /// Required Roles: `Any`
    /// </remarks>
	[Authorize]
	[HttpDelete("{id}")]
	[ProducesResponseType(204)]
	[ProducesResponseType(404)]
	public async Task<IActionResult> Delete(Guid id)
	{
	    await _devicesService.Delete(id);
	    return Ok();
	}
	#endregion
}
