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
public class NewsesController : BaseController
{
	private readonly INewsesService _newsesService;

	public NewsesController(INewsesService newsesService)
	{
		_newsesService = newsesService;
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
	public async Task<ActionResult<Response<PagedList<NewsSimpleDTO>>>> GetAll([FromQuery] NewsFilter filter) =>
		Ok(await _newsesService.GetAll(filter));

    /// <summary>
    /// Retrieves a single instance by its ID
    /// </summary>
    /// <remarks>
    /// Required Roles: `Any`
    /// </remarks>
	[Authorize]
	[HttpGet("{id}")]
	public async Task<ActionResult<Response<NewsDTO>>> GetById(Guid id) =>
		Ok(await _newsesService.GetById(id));

    /// <summary>
    /// Creates a new instance 
    /// </summary>
    /// <remarks>
    /// Required Roles: `super-admin`
    /// status:'Draft = 0 , Published = 10 ,Unpublished = 20'
    /// </remarks>
    [Authorize(Roles = "super-admin")]
    [HttpPost]
	public async Task<ActionResult<Response<NewsDTO>>> Create([Required] [FromBody] NewsFormDTO form)
	{
		form.Editor = CurId;
     return Ok(await _newsesService.Create(form));
    }


    /// <summary>
    /// Updates an instance determined by its ID
    /// </summary>
    /// <remarks>
    /// Required Roles: `super-admin`
    /// </remarks>
    [Authorize(Roles = "super-admin")]
    [HttpPut("{id}")]
	[ProducesResponseType(204)]
	[ProducesResponseType(404)]
	public async Task<IActionResult> Update([Required] [FromBody] NewsUpdateDTO update, Guid id)
	{
		update.Id = id;
		await _newsesService.Update(update);
		
		return Ok();
	}

    /// <summary>
    /// Deletes an instance determined by its ID
    /// </summary>
    /// <remarks>
    /// Required Roles: `super-admin`
    /// </remarks>
	[Authorize(Roles = "super-admin")]
    [HttpDelete("{id}")]
	[ProducesResponseType(204)]
	[ProducesResponseType(404)]
	public async Task<IActionResult> Delete(Guid id)
	{
	    await _newsesService.Delete(id);
	    return Ok();
	}
	#endregion
}
