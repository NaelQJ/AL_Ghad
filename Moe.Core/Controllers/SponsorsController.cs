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
public class SponsorsController : BaseController
{
    private readonly ISponsorsService _sponsorsService;

    public SponsorsController(ISponsorsService sponsorsService)
    {
        _sponsorsService = sponsorsService;
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
    public async Task<ActionResult<Response<PagedList<SponsorDTO>>>> GetAll([FromQuery] SponsorFilter filter) =>
        Ok(await _sponsorsService.GetAll(filter));

    /// <summary>
    /// Retrieves a single instance by its ID
    /// </summary>
    /// <remarks>
    /// Required Roles: `Any`
    /// </remarks>
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<Response<SponsorDTO>>> GetById(Guid id) =>
        Ok(await _sponsorsService.GetById(id));

    /// <summary>
    /// Creates a new instance
    /// </summary>
    /// <remarks>
    /// Required Roles: `Any`
    /// </remarks>
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Response<SponsorDTO>>> Create([Required][FromBody] SponsorFormDTO form)
    {
        form.UserId = CurId;
        return Ok(await _sponsorsService.Create(form));
    }

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
    public async Task<IActionResult> Update([Required][FromBody] SponsorUpdateDTO update, Guid id)
    {
        update.Id = id;
        await _sponsorsService.Update(update);

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
        await _sponsorsService.Delete(id);
        return Ok();
    }
    #endregion
}
