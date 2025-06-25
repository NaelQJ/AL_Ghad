using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Moe.Core.Models.Entities;

public class Support : BaseEntity
{
    #region One-To-N
    #endregion

    #region Functional
    #endregion

    #region Non-Functional
    [MaxLength(128)]
    public string Title { get; set; }
    [MaxLength(1024)]
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public Status status { get; set; } = Status.Pending;
    #endregion

    #region Many-To-N
    #endregion
}
