using Moe.Core.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Moe.Core.Models.DTOs;

public class SupportDTO : BaseDTO
{
    #region Auto
    #endregion

    #region Manual
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public Status status { get; set; } = Status.Pending;
    #endregion
} 

public class SupportFormDTO : BaseFormDTO
{
    [Required, MaxLength(128)]
    public string Title { get; set; }
    [Required, MaxLength(1024)]
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public Status status { get; set; } = Status.Pending;
}

public class SupportUpdateDTO : BaseUpdateDTO
{
    public string?Title { get; set; }
    public string?Description { get; set; }
    public string?ImageUrl { get; set; }
    public Status?status { get; set; } = Status.Pending;
}

public class SupportFilter : BaseFilter
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public Status status { get; set; } = Status.Pending;
}
