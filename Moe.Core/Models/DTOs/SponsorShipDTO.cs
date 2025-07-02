using Moe.Core.Models.Entities;

namespace Moe.Core.Models.DTOs;

public class SponsorShipDTO : BaseDTO
{
    #region Auto
    public SponsorDetailsDTO Sponsor { get; set; }
    public OrphanDetailsDTO? Orphan { get; set; }
    public FamilyDetailsDTO? Family { get; set; }
    #endregion

    #region Manual
    #endregion
} 



public class SponsorDetailsDTO
{
    public string FullName { get; set; }
    public DateTime Birthday { get; set; }
    public string? SponsoredFor { get; set; } 
    public DateTime StartSpons { get; set; }

}
public class FamilyDetailsDTO
{
    public string FatherName { get; set; }
    public string MotherName { get; set; }
    public string CurrentAddressRegion { get; set; }

}
public class OrphanDetailsDTO
{
    public string FullName { get; set; }
    public DateTime Birthday { get; set; }
    public string Gender { get; set; }
    public string? IllnessName { get; set; }

}

public class SponsorShipFormDTO : BaseFormDTO
{
    public Guid SponsorId { get; set; }
    public Guid? OrphanId { get; set; }
    public Guid? FamilyId { get; set; }

}

public class SponsorShipUpdateDTO : BaseUpdateDTO
{
    public Guid? SponsorId { get; set; }
    public Guid? OrphanId { get; set; }
    public Guid? FamilyId { get; set; }
    public Status? Status { get; set; }

}

public class SponsorShipFilter : BaseFilter
{
    public Guid? SponsorId { get; set; }
    public Guid? OrphanId { get; set; }
    public Guid? FamilyId { get; set; }
    public Status? Status { get; set; }

}
