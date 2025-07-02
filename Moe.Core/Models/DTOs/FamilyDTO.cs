using Moe.Core.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Moe.Core.Models.DTOs;

public class FamilyDTO : BaseDTO
{
    #region Functional
    public bool IsActive { get; set; } 
    public bool IsSponsored { get; set; } 
    public Status Status { get; set; } 
    #endregion

    public FatherInfoDTO Father { get; set; }
    public MotherInfoDTO Mother { get; set; }
    public CurrentHousingDTO CurrentHousing { get; set; }
    public PreviousHousingDTO PreviousHousing { get; set; }
    public IncomeInfoDTO Income { get; set; }
    public ProjectInfoDTO Project { get; set; }

    public List<string> Documents { get; set; }

    public List<WarehouseSimpleDTO> Warehouses { get; set; } = new();
    public List<OrphanFamilyDTO> Orphans { get; set; } = new();
}

public class OrphanFamilyDTO : BaseDTO
{
     
    public string FullName { get; set; }
    public DateTime Birthday { get; set; }
    public bool IsSponsored { get; set; }
    public int Score { get; set; }

}

public class WarehouseFamilyDTO : BaseDTO
{
    public string DonationType { get; set; }
    public int Qty { get; set; }
    public decimal DonationAmount { get; set; }
    public string DonationStatus { get; set; }
    public string ReceivedName { get; set; }
    public string DonorName { get; set; }
    public string? FamilyName { get; set; }
}

 public class FamilySimpleDTO : BaseDTO
{
    #region Auto
    #endregion

    #region Manual
    public string FatherName { get; set; }
    public int OrphanCount { get; set; }
    public int Score { get; set; }
    public string SponsorName { get; set; }
    public bool IsActive { get; set; }
    public bool IsSponsored { get; set; } 
    #endregion
}


public class FamilyFormDTO : BaseFormDTO
{
    public FatherInfoDTO Father { get; set; } = new();
    public MotherInfoDTO Mother { get; set; } = new();
    public CurrentHousingDTO CurrentHousing { get; set; } = new();
    public PreviousHousingDTO PreviousHousing { get; set; } = new();
    public IncomeInfoDTO Income { get; set; } = new();
    public ProjectInfoDTO Project { get; set; } = new();
    public List<FamilyDeviceDTO> Device { get; set; } = new();
    public string Notes { get; set; }


    public ICollection<string> Documents { get; set; } = new List<string>();
   
}
public class FatherInfoDTO
{
    [Required, MaxLength(128)]
    public string FatherName { get; set; }

    [Required, MaxLength(128)]
    public string DeathCause { get; set; }

    [Required]
    public DateTime DeathDate { get; set; }

    [Required, MaxLength(128)]
    public string FatherJob { get; set; }

    [MaxLength(128)]
    public string? SecondDeceasedName { get; set; }

    [Range(1, int.MaxValue)]
    public int OrphanCount { get; set; }

    public string? FamliyImge { get; set; }
}
public class MotherInfoDTO
{
    [Required, MaxLength(128)]
    public string MotherName { get; set; }

    [Required, MaxLength(128)]
    public string MotherStudy { get; set; }

    [Required, MaxLength(128)]
    public string MotherJop { get; set; }

    [Required, MaxLength(16)]
    public string MotherPhone { get; set; }
}
public class CurrentHousingDTO
{
    [MaxLength(128)]
    public string CurrentAddress { get; set; }

    [MaxLength(128)]
    public string CurrentFullAddress { get; set; }

    [MaxLength(128)]
    public string CurrentHousingType { get; set; }

    public int CurrentRoomCount { get; set; }
    public decimal? CurrentRentAmount { get; set; }
}
public class PreviousHousingDTO
{
    [MaxLength(128)]
    public string PreviousAddress { get; set; }

    [MaxLength(128)]
    public string PreviousFullAddress { get; set; }

    [MaxLength(128)]
    public string PreviousHousingType { get; set; }

    public int PreviousRoomCount { get; set; }

    [MaxLength(128)]
    public string NearestLandmark { get; set; }
}
public class IncomeInfoDTO
{
    [Range(10, 1000000)]
    public decimal Totalincome { get; set; }

    [MaxLength(128)]
    public string? Retirement { get; set; }

    [MaxLength(128)]
    public string? Assistance { get; set; }

    [MaxLength(128)]
    public string? Welfare { get; set; }
}
public class ProjectInfoDTO
{
    [MaxLength(128)]
    public string? FamilyProject { get; set; }

    public int WorkingCount { get; set; }

    [MaxLength(128)]
    public string? ProjectType { get; set; }

    public bool? CanDevelopProject { get; set; }
    public bool? CanStartNewProject { get; set; }
    public decimal? ProposedBudget { get; set; }
}







public class FamilyUpdateDTO : BaseUpdateDTO
{
    public FatherInfoUpdateDTO Father { get; set; } = new();
    public MotherInfoUpdateDTO Mother { get; set; } = new();
    public CurrentHousingUpdateDTO CurrentHousing { get; set; } = new();
    public PreviousHousingUpdateDTO PreviousHousing { get; set; } = new();
    public IncomeInfoUpdateDTO Income { get; set; } = new();
    public ProjectInfoUpdateDTO Project { get; set; } = new();

    public string? Notes { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsSponsored { get; set; }

    public ICollection<string>? Documents { get; set; }
  
}
public class FatherInfoUpdateDTO
{
    public string? FatherName { get; set; }
    public string? DeathCause { get; set; }
    public DateTime? DeathDate { get; set; }
    public string? FatherJob { get; set; }
    public string? SecondDeceasedName { get; set; }
    public int? OrphanCount { get; set; }
    public string? FamliyImge { get; set; }
}
public class MotherInfoUpdateDTO
{
    public string? MotherName { get; set; }
    public string? MotherStudy { get; set; }
    public string? MotherJop { get; set; }
    public string? MotherPhone { get; set; }
}
public class CurrentHousingUpdateDTO
{
    [MaxLength(128)]
    public string? CurrentAddress { get; set; }

    [MaxLength(128)]
    public string? CurrentFullAddress { get; set; }

    [MaxLength(128)]
    public string? CurrentHousingType { get; set; }

    public int? CurrentRoomCount { get; set; }
    public decimal? CurrentRentAmount { get; set; }
}
public class PreviousHousingUpdateDTO
{
    [MaxLength(128)]
    public string? PreviousAddress { get; set; }

    [MaxLength(128)]
    public string? PreviousFullAddress { get; set; }

    [MaxLength(128)]
    public string? PreviousHousingType { get; set; }

    public int? PreviousRoomCount { get; set; }

    [MaxLength(128)]
    public string? NearestLandmark { get; set; }
}
public class IncomeInfoUpdateDTO
{
    [Range(10, 1000000)]
    public decimal? Totalincome { get; set; }

    [MaxLength(128)]
    public string? Retirement { get; set; }

    [MaxLength(128)]
    public string? Assistance { get; set; }

    [MaxLength(128)]
    public string? Welfare { get; set; }
}
public class ProjectInfoUpdateDTO
{
    [MaxLength(128)]
    public string? FamilyProject { get; set; }

    public int? WorkingCount { get; set; }

    [MaxLength(128)]
    public string? ProjectType { get; set; }

    public bool? CanDevelopProject { get; set; }
    public bool? CanStartNewProject { get; set; }
    public decimal? ProposedBudget { get; set; }
}


public class FamilyFilter : BaseFilter
{
    public string? FatherName { get; set; }
    public string? MotherName { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsSponsored { get; set; } 
}
