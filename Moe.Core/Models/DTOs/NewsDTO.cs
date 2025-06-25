using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moe.Core.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Moe.Core.Models.DTOs;

public class NewsDTO : BaseDTO
{
    #region Auto
   
    #endregion

    #region Manual
    public string Title { get; set; }
    public string Content { get; set; }
    public string CoverImage { get; set; }
    public StatusNews Status { get; set; }
    #endregion

} 

public class NewsFormDTO : BaseFormDTO
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public string CoverImage { get; set; }

    [Required]
    public StatusNews Status { get; set; }

    [JsonIgnore]
    [BindNever]
    public Guid Editor { get; set; }
}

public class NewsUpdateDTO : BaseUpdateDTO
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? CoverImage { get; set; }
    public StatusNews? Status { get; set; }
}

public class NewsFilter : BaseFilter
{

    public string? Title { get; set; }
    public string? Content { get; set; }
    public StatusNews? Status { get; set; }
}
