using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moe.Core.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Moe.Core.Models.DTOs;

public class SponsorDTO : BaseDTO
{
    #region Auto
    #endregion

    #region Manual
    public Status Status { get; set; }
    public Payment PaymentMethod { get; set; }
    public string FullName { get; set; }
    public DateTime Birthday { get; set; }
    public string? SponsoredFor { get; set; } // The person under whose name the sponsorship is
    public bool? IsDead { get; set; }
    public DateTime? DeathDate { get; set; }
    public string JobTitle { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Study { get; set; }
    public int OrphanCount { get; set; }
    public decimal AmountOrphan { get; set; } // The amount allocated to each orphan
    public DateTime StartSpons { get; set; }
    public string HowFoundUs { get; set; } // How did you find out about the organization?
    public string Intermediary { get; set; } // The person I knew inside the organization to the organization
    #endregion
}

public class SponsorFormDTO : BaseFormDTO
{

    public Status Status { get; set; }
    public Payment PaymentMethod { get; set; }

    [Required]
    [MaxLength(128)]
    public string FullName { get; set; }

    public DateTime Birthday { get; set; }

    [MaxLength(128)]
    public string? SponsoredFor { get; set; } // The person under whose name the sponsorship is

    public bool? IsDead { get; set; }

    public DateTime? DeathDate { get; set; }

    [Required]
    [MaxLength(128)]
    public string JobTitle { get; set; }

    [Required]
    [MaxLength(128)]
    public string Address { get; set; }

    [Required]
    [MaxLength(16)]
    public string Phone { get; set; }

    [Required]
    [MaxLength(128)]
    public string Study { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int OrphanCount { get; set; }

    public decimal AmountOrphan { get; set; } // The amount allocated to each orphan

    public DateTime StartSpons { get; set; }

    [Required]
    [MaxLength(128)]
    public string HowFoundUs { get; set; } 

    [Required]
    [MaxLength(128)]
    public string Intermediary { get; set; } // The person I knew inside the organization to the organization

    [JsonIgnore]
    [BindNever]
    public Guid UserId { get; set; }

}

public class SponsorUpdateDTO : BaseUpdateDTO
{

    public Status? Status { get; set; }
    public Payment? PaymentMethod { get; set; }

    public string? FullName { get; set; }

    public DateTime? Birthday { get; set; }
    public string? SponsoredFor { get; set; } // The person under whose name the sponsorship is
    public bool? IsDead { get; set; }
    public DateTime? DeathDate { get; set; }
    public string? JobTitle { get; set; }
    public string? Address { get; set; }
 
    public string? Phone { get; set; }

    public string? Study { get; set; }

    public int? OrphanCount { get; set; }

    public decimal? AmountOrphan { get; set; } 

    public DateTime? StartSpons { get; set; }

    public string? HowFoundUs { get; set; } 
    public string? Intermediary { get; set; } // The person I knew inside the organization to the organization

}

public class SponsorFilter : BaseFilter
{
    public Status? Status { get; set; }
    public Payment? PaymentMethod { get; set; }
    public string? FullName { get; set; }
    public int? OrphanCount { get; set; }
    public DateTime? StartSpons { get; set; }
    public string? JobTitle { get; set; }
    public string? Address { get; set; }
    public Guid? UserId { get; set; }
}
