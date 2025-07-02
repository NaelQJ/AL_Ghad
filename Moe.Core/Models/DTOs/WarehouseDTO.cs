using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Moe.Core.Models.DTOs.Auth;
using Moe.Core.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Moe.Core.Models.DTOs;

public class WarehouseDTO : BaseDTO
{
    #region Auto
    #endregion

    #region Manual
    public DonationDTO Donation { get; set; }
    public BeneficiaryDTO beneficiary { get; set; }
    #endregion
}
public class DonationDTO 
{
    public string DonorName { get; set; }
    public string DonationType { get; set; }
    public string DonationStatus { get; set; }
    public string ReceivedName { get; set; }

}

public class BeneficiaryDTO 
{
    public string Name { get; set; }
    public int OrphanCount { get; set; }
    public string CurrentFullAddress { get; set; }
}

public class WarehouseSimpleDTO : BaseDTO
{
    public string DonationType { get; set; }
    public int Qty { get; set; }
    public decimal DonationAmount { get; set; }
    public string DonationStatus { get; set; }
    public string ReceivedName { get; set; }
    public string DonorName { get; set; }
    public string? FamilyName { get; set; }
}



public class WarehouseFormDTO : BaseFormDTO
{
    [Required]
    [MaxLength(128)]
    public string DonorName { get; set; }

    [Required]
    [MaxLength(16)]
    public string PhoneNumber { get; set; }

    [MaxLength(64)]
    public string? Email { get; set; }

    [Required]
    [MaxLength(128)]
    public string DonationType { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Qty { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal DonationAmount { get; set; }

    [Required]
    [MaxLength(128)]
    public string DonationImage { get; set; }

    [MaxLength(128)]
    public string DonationStatus { get; set; }

    [MaxLength(128)]
    public string? Donationlocation { get; set; }

    [Required]
    [MaxLength(128)]
    public string ReceivedName { get; set; }
}


public class WarehouseUpdateDTO : BaseUpdateDTO
{

    public string? DonorName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? DonationType { get; set; }
    public int? Qty { get; set; }
    public decimal? DonationAmount { get; set; }
    public string? DonationImage { get; set; }
    public string? DonationStatus { get; set; }
    public string? Donationlocation { get; set; }
    public string? ReceivedName { get; set; }
}

public class WarehouseFilter : BaseFilter
{
    public string? DonationType { get; set; }
    public int? Qty { get; set; }
    public decimal? DonationAmount { get; set; }
    public string? DonationStatus { get; set; }
    public string? ReceivedName { get; set; }
    public string? DonorName { get; set; }
    public Guid? FamilyId { get; set; }
    public Guid? OrphanId { get; set; }
    public ItemType? Type { get; set; }

}



public class ItemOutDTO
{
    [Required]
    public Guid ItemId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Qty { get; set; }
}
public class WarehouseFormOutDTO : BaseFormDTO
{


    public Guid? FamilyId { get; set; }
    public Guid? OrphanId { get; set; }
    [Required]
    public string ReceivedName { get; set; }

    [Required]
    public List<ItemOutDTO> Items { get; set; } = new();


}
public class FormOutFluentValidator : AbstractValidator<WarehouseFormOutDTO>
{
    public FormOutFluentValidator()
    {
        RuleFor(x => x.FamilyId)
              .Must((model, familyId) => familyId != null || model.OrphanId != null)
              .WithMessage("Either FamilyId or OrphanId must be provided.");
    }
}


public class WarehouseOutDTO : BaseFormDTO
{


    public Guid? FamilyId { get; set; }
    public Guid? OrphanId { get; set; }

    public List<ItemOutDTO> Items { get; set; } = new();

    public string ReceivedName { get; set; }
}
