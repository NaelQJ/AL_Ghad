using System.ComponentModel.DataAnnotations;

namespace Moe.Core.Models.Entities;

public class Warehouse : BaseEntity
{
    #region One-To-N
    public Family Family { get; set; }
    public Guid? FamilyId { get; set; }

    public Orphan Orphan { get; set; }
    public Guid? OrphanId { get; set; }
    #endregion

    #region Functional

    #endregion
    #region Non-Functional
    [MaxLength(128)]
    public string DonorName { get; set; }

    [MaxLength(16)]
    public string PhoneNumber { get; set; }

    [MaxLength(64)]
    public string? Email { get; set; }

    [MaxLength(128)]
    public string DonationType { get; set; }

    [Range(1, int.MaxValue)]
    public int Qty { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal DonationAmount { get; set; }

    [MaxLength(128)]
    public string DonationImage { get; set; }

    [MaxLength(128)]
    public string DonationStatus { get; set; } 

    public ItemType Type { get; set; }

    [MaxLength(128)]
    public string Donationlocation { get; set; }

    [MaxLength(128)]
    public string ReceivedName { get; set; }

    public Guid? MovId { get; set; } // Movement ID for tracking the donation movement

    #endregion

    #region Many-To-N
    #endregion
}


public enum ItemType
{
    In = 0,
    Out = 1,
}
