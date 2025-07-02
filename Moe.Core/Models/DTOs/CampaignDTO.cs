

using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moe.Core.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Moe.Core.Models.DTOs;

public class CampaignDTO : BaseDTO
{
    #region Auto
    public Guid Editor { get; set; }
    #endregion

    #region Manual
    public string Title { get; set; }
    public string Beneficiary { get; set; }
    public decimal TargetAmount { get; set; }
    public DateTime StartDate { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    #endregion

}

public class CampaignSimpleDTO : BaseDTO
{
    public string Title { get; set; }

    public decimal TargetAmount { get; set; }
    public decimal RemainingAmount { get; set; } = 0;
    public StatusCampaign Status { get; set; }
}

public class CampaignFormDTO : BaseFormDTO
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Beneficiary { get; set; }
    [Required]
    public decimal TargetAmount { get; set; }
    public DateTime StartDate { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string ImageUrl { get; set; }
    [Required]
    public StatusCampaign Status { get; set; }

    [JsonIgnore]
    [BindNever]
    public Guid Editor { get; set; }
}

public class CampaignValdation : AbstractValidator<CampaignFormDTO>
{
    public CampaignValdation()
    {
        RuleFor(x => x.Status)
       .IsInEnum()
       .WithMessage("Invalid status selected.");
    }
}


public class CampaignUpdateDTO : BaseUpdateDTO
{

    public string? Title { get; set; }
    public string? Beneficiary { get; set; }
    public decimal? TargetAmount { get; set; }
    public DateTime? StartDate { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public StatusCampaign? Status { get; set; }
}

public class CampaignFilter : BaseFilter
{
    public string? Title { get; set; }
    public string? Beneficiary { get; set; }
    public DateTime? StartDate { get; set; }
    public decimal? TargetAmount { get; set; }
    public string? Description { get; set; }
    public StatusCampaign? Status { get; set; }
}
