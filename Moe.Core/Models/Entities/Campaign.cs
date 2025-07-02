using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moe.Core.Models.Entities;

public class Campaign : BaseEntity
{
    #region One-To-N
    #endregion

    #region Functional
    public StatusCampaign Status { get; set; }
    #endregion

    #region Non-Functional


    [MaxLength(128)]
    public string Title { get; set; }

    [MaxLength(128)]
    public string Beneficiary { get; set; }

    public decimal TargetAmount { get; set; }

    public DateTime StartDate { get; set; }

    [MaxLength(1024)]
    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public Guid Editor { get; set; }
    public decimal? RemainingAmount { get; set; }
    #endregion

    #region Many-To-N
    #endregion
}

public enum StatusCampaign
{
    Draft = 0,
    Completed = 10,
    Active = 20,
}
