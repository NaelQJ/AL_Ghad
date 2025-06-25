using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moe.Core.Models.Entities;

public class News : BaseEntity
{

    #region Functional
    public StatusNews Status { get; set; }
    #endregion

    #region Non-Functional
    [MaxLength(128)]
    public string Title { get; set; }

    [MaxLength(1024)]
    public string Content { get; set; }

    public string CoverImage { get; set; }
    public Guid Editor { get; set; }
    #endregion
}


public enum StatusNews
{
    Draft = 0,
    Published = 10,
    Unpublished = 20
}


