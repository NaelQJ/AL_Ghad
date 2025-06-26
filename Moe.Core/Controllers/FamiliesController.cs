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
public class FamiliesController : BaseController
{
	private readonly IFamiliesService _familiesService;

	public FamiliesController(IFamiliesService familiesService)
	{
		_familiesService = familiesService;
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
	public async Task<ActionResult<Response<PagedList<FamilySimpleDTO>>>> GetAll([FromQuery] FamilyFilter filter) =>
		Ok(await _familiesService.GetAll(filter));

    /// <summary>
    /// Retrieves a single instance by its ID
    /// </summary>
    /// <remarks>
    /// Required Roles: `Any`
    /// </remarks>
	[Authorize]
	[HttpGet("{id}")]
	public async Task<ActionResult<Response<FamilyDTO>>> GetById(Guid id) =>
		Ok(await _familiesService.GetById(id));

    /// <summary>
    /// Creates a new instance
    /// </summary>
    /// <remarks>
    /// Required Roles: `Any`
    /// Status : '  Active = 10 ,Pending = 0, Rejected =20'
    /// </remarks>
    [Authorize]
	[HttpPost]
	public async Task<ActionResult<Response<FamilySimpleDTO>>> Create([Required] [FromBody] FamilyFormDTO form) =>
		Ok(await _familiesService.Create(form));

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
	public async Task<IActionResult> Update([Required] [FromBody] FamilyUpdateDTO update, Guid id)
	{
		update.Id = id;
		await _familiesService.Update(update);
		
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
	    await _familiesService.Delete(id);
	    return Ok();
	}
	#endregion
}
