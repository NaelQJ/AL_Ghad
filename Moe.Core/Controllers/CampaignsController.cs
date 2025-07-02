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
public class CampaignsController : BaseController
{
    private readonly ICampaignsService _campaignsService;

    public CampaignsController(ICampaignsService campaignsService)
    {
        _campaignsService = campaignsService;
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
    public async Task<ActionResult<Response<PagedList<CampaignDTO>>>> GetAll([FromQuery] CampaignFilter filter) =>
        Ok(await _campaignsService.GetAll(filter));

    /// <summary>
    /// Retrieves a single instance by its ID
    /// </summary>
    /// <remarks>
    /// Required Roles: `Any`
    /// </remarks>
	[Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<Response<CampaignDTO>>> GetById(Guid id) =>
        Ok(await _campaignsService.GetById(id));

    /// <summary>
    /// Creates a new instance
    /// </summary>
    /// <remarks>
    /// Required Roles: `super-admin`
    /// status : ' Draft = 0 , Completed = 10,  Active = 20,' 
    /// </remarks>
    [Authorize(Roles = "super-admin")]
    [HttpPost]
    public async Task<ActionResult<Response<CampaignDTO>>> Create([Required][FromBody] CampaignFormDTO form)
    {
        form.Editor = CurId;
        return Ok(await _campaignsService.Create(form));
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
    public async Task<IActionResult> Update([Required][FromBody] CampaignUpdateDTO update, Guid id)
    {
        update.Id = id;
        await _campaignsService.Update(update);

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
        await _campaignsService.Delete(id);
        return Ok();
    }
    #endregion
}
