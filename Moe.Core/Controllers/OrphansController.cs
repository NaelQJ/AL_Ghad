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
public class OrphansController : BaseController
{
	private readonly IOrphansService _orphansService;

	public OrphansController(IOrphansService orphansService)
	{
		_orphansService = orphansService;
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
	public async Task<ActionResult<Response<PagedList<OrphanSimplDTO>>>> GetAll([FromQuery] OrphanFilter filter) =>
		Ok(await _orphansService.GetAll(filter));

    /// <summary>
    /// Retrieves a single instance by its ID
    /// </summary>
    /// <remarks>
    /// Required Roles: `Any`
    /// </remarks>
	[Authorize]
	[HttpGet("{id}")]
	public async Task<ActionResult<Response<OrphanDTO>>> GetById(Guid id) =>
		Ok(await _orphansService.GetById(id));

    /// <summary>
    /// Creates a new instance
    /// </summary>
    /// <remarks>
    /// Required Roles: `Any`
    /// </remarks>
	[Authorize]
	[HttpPost]
	public async Task<ActionResult<Response<OrphanSimplDTO>>> Create([Required] [FromBody] OrphanFormDTO form) =>
		Ok(await _orphansService.Create(form));

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
	public async Task<IActionResult> Update([Required] [FromBody] OrphanUpdateDTO update, Guid id)
	{
		update.Id = id;
		await _orphansService.Update(update);
		
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
	    await _orphansService.Delete(id);
	    return Ok();
	}
	#endregion
}
