using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moe.Core.ActionFilters;
using Moe.Core.Helpers;
using Moe.Core.Services;

namespace Moe.Core.Controllers;

[Authorize]
public class FilesController : BaseController
{
    private readonly IFilesService _filesService;

    public FilesController(IFilesService filesService)
    {
        _filesService = filesService;
    }

    [HttpPost]
    public async Task<ActionResult<string>> Upload([Required] IFormFile file) =>
        Ok(new Response<string>(await _filesService.Upload(file), null, 200));
}