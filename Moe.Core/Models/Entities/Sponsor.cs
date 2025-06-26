using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moe.Core.Models.Entities;

public class Sponsor : BaseEntity
{
    #region One-To-N
    public User User { get; set; }
    public Guid UserId { get; set; }
    #endregion

    #region Functional

    public Status Status { get; set; } = Status.Pending;

    public Payment PaymentMethod { get; set; } = Payment.Cash;

    #endregion

    #region Non-Functional

    [MaxLength(128)]
    public string FullName { get; set; }

    public DateTime Birthday { get; set; }

    [MaxLength(128)]
    public string? SponsoredFor { get; set; } // The person under whose name the sponsorship is

    public bool? IsDead { get; set; }

    public DateTime? DeathDate { get; set; }


    [MaxLength(128)]
    public string JobTitle { get; set; }

 
    [MaxLength(128)]
    public string Address { get; set; }


    [MaxLength(16)]
    public string Phone { get; set; }


    [MaxLength(128)]
    public string Study { get; set; }

    public int OrphanCount { get; set; }

    public decimal AmountOrphan { get; set; } // The amount allocated to each orphan

    public DateTime StartSpons { get; set; }

  
    [MaxLength(128)]
    public string? HowFoundUs { get; set; } // How did you find out about the organization?


    [MaxLength(128)]
    public string? Intermediary { get; set; } // The person I knew inside the organization to the organization
    public int Score { get; set; }

    #endregion

    #region Many-To-N
    public ICollection<SponsorShip> SponsorShips { get; set; } = new List<SponsorShip>();
    #endregion
}


public enum Status
{
    Active = 10,
    Pending = 0,
    Rejected = 20

}

public enum Payment
{
    Cash = 0,
    CreditCard = 1,
}
