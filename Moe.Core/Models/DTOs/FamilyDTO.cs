using Moe.Core.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Moe.Core.Models.DTOs;

public class FamilyDTO : BaseDTO
{
    #region Auto
    #endregion

    #region Manual
    public string FatherName { get; set; }
    public string DeathCause { get; set; }
    public DateTime DeathDate { get; set; }
    public string FatherJob { get; set; }
    public string SecondDeceasedName { get; set; }
    public string MotherName { get; set; }
    public string MotherStudy { get; set; }
    public string MotherJop { get; set; }
    public string MotherPhone { get; set; }
    public string CurrentAddressRegion { get; set; }
    public string CurrentHousingType { get; set; }
    public int? CurrentRoomCount { get; set; }
    public string CurrentFullAddress { get; set; }
    public decimal CurrentRentAmount { get; set; }
    public string CurrentNearestLandmark { get; set; }
    public string? PreviousAddressRegion { get; set; }
    public string? PreviousHousingType { get; set; }
    public int? PreviousRoomCount { get; set; }
    public string? PreviousFullAddress { get; set; }
    public string? PreviousNearestLandmark { get; set; }
    public decimal FamilyIncome { get; set; }
    public string? RetirementProvider { get; set; }
    public string? AssistanceProvider { get; set; }
    public string? WelfareProvider { get; set; }
    public string? FamilyProjectName { get; set; }
    public int? WorkingMembersCount { get; set; }
    public int OrphanCount { get; set; }
    public string? ProjectType { get; set; }
    public bool CanDevelopProject { get; set; }
    public bool CanStartNewProject { get; set; }
    public decimal? ProposedBudget { get; set; }
    public string? Notes { get; set; }
    public int Score { get; set; } = 0;
    public Status Status { get; set; }
    #endregion
}

public class FamilyFormDTO : BaseFormDTO
{
    #region Manual

    [Required, MaxLength(128)]
    public string FatherName { get; set; }

    [Required, MaxLength(128)]
    public string DeathCause { get; set; }

    [Required]
    public DateTime DeathDate { get; set; }

    [Required, MaxLength(128)]
    public string FatherJob { get; set; }

    [MaxLength(128)]
    public string SecondDeceasedName { get; set; }

    [Required, MaxLength(128)]
    public string MotherName { get; set; }

    [Required, MaxLength(128)]
    public string MotherStudy { get; set; }

    [Required, MaxLength(128)]
    public string MotherJop { get; set; }

    [Required, MaxLength(16)]
    public string MotherPhone { get; set; }

    [Required, MaxLength(64)]
    public string CurrentAddressRegion { get; set; }

    [Required, MaxLength(32)]
    public string CurrentHousingType { get; set; }

    [Required]
    public int CurrentRoomCount { get; set; }

    [Required, MaxLength(256)]
    public string CurrentFullAddress { get; set; }

    [Required]
    public decimal CurrentRentAmount { get; set; }

    [Required, MaxLength(128)]
    public string CurrentNearestLandmark { get; set; }

    [MaxLength(64)]
    public string? PreviousAddressRegion { get; set; }

    [MaxLength(32)]
    public string? PreviousHousingType { get; set; }

    public int? PreviousRoomCount { get; set; }

    [MaxLength(256)]
    public string? PreviousFullAddress { get; set; }

    [MaxLength(128)]
    public string? PreviousNearestLandmark { get; set; }

    [Required]
    public decimal FamilyIncome { get; set; }

    [MaxLength(128)]
    public string? RetirementProvider { get; set; }

    [MaxLength(128)]
    public string? AssistanceProvider { get; set; }

    [MaxLength(128)]
    public string? WelfareProvider { get; set; }

    [MaxLength(128)]
    public string? FamilyProjectName { get; set; }

    public int? WorkingMembersCount { get; set; }
    public int OrphanCount { get; set; }

    [MaxLength(64)]
    public string? ProjectType { get; set; }

    public bool? CanDevelopProject { get; set; }

    public bool? CanStartNewProject { get; set; }

    public decimal? ProposedBudget { get; set; }

    [MaxLength(1024)]
    public string? Notes { get; set; }

    [Required]
    public int Score { get; set; } = 0;

    [Required]
    public Status Status { get; set; }

    public ICollection<string> Documents { get; set; } = new List<string>();
    public ICollection<string> Devices { get; set; } = new List<string>();

    #endregion
}

public class FamilyUpdateDTO : BaseUpdateDTO
{
    public string? FatherName { get; set; }
    public string? DeathCause { get; set; }
    public DateTime? DeathDate { get; set; }
    public string? FatherOccupation { get; set; }
    public string? SecondDeceasedName { get; set; }
    public string? MotherName { get; set; }
    public string? MotherEducationLevel { get; set; }
    public string? MotherOccupation { get; set; }
    public string? MotherPhoneNumber { get; set; }
    public string? CurrentAddressRegion { get; set; }
    public string? CurrentHousingType { get; set; }
    public int? CurrentRoomCount { get; set; }
    public string? CurrentFullAddress { get; set; }
    public decimal? CurrentRentAmount { get; set; }
    public string? CurrentNearestLandmark { get; set; }
    public string? PreviousAddressRegion { get; set; }
    public string? PreviousHousingType { get; set; }
    public int? PreviousRoomCount { get; set; }
    public string? PreviousFullAddress { get; set; }
    public string? PreviousNearestLandmark { get; set; }
    public decimal? FamilyIncome { get; set; }
    public string? RetirementProvider { get; set; }
    public string? AssistanceProvider { get; set; }
    public string? WelfareProvider { get; set; }
    public string? FamilyProjectName { get; set; }
    public int? WorkingMembersCount { get; set; }
    public string? ProjectType { get; set; }
    public bool? CanDevelopProject { get; set; }
    public bool? CanStartNewProject { get; set; }
    public decimal? ProposedBudget { get; set; }
    public string? Notes { get; set; }
    public string? ApplianceType { get; set; }
    public string? ApplianceImageUrl { get; set; }
    public int? Score { get; set; } = 0;

    public Status? Status { get; set; }
    public List<Guid> OrphanIds { get; set; } = new List<Guid>();


}

public class FamilyFilter : BaseFilter
{
    public string? FatherName { get; set; }
    public string? MotherName { get; set; }
    public Status? Status { get; set; }

}
