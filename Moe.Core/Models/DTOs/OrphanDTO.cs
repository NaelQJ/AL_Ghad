using System.ComponentModel.DataAnnotations;

namespace Moe.Core.Models.DTOs;

public class OrphanDTO : BaseDTO
{
    #region Auto
    #endregion

    #region Manual
    public Guid FamilyId { get; set; }
    public string FullName { get; set; }
    public DateTime Birthday { get; set; }
    public string Gender { get; set; }
    public string Lineage { get; set; }
    public string? IllnessName { get; set; }
    public DateTime? IllnessDate { get; set; }
    public string? IllnessStatus { get; set; }
    public string? IllnessType { get; set; }
    public string? PreviousSurgeries { get; set; }
    public string? PermanentDisabilities { get; set; }
    public bool? IsHereditary { get; set; }
    public string? MedFollowUp { get; set; }
    public int? MedFollowUpCount { get; set; }
    public decimal? TotalAmount { get; set; }
    public string? MedSpecialty { get; set; }
    public string? MedicalNotes { get; set; }
    public string SchoolStatus { get; set; }
    public string SchoolName { get; set; }
    public string SchoolType { get; set; }
    public decimal? SchoolFees { get; set; }
    public string SchoolFeesSource { get; set; }
    public string SchoolAddress { get; set; }
    public string? SchoolNotes { get; set; }
    public string? TalentType { get; set; }
    public string? TalentNotes { get; set; }
    public int Score { get; set; }
    public bool IsSponsored { get; set; } 


    #endregion

}
public class OrphanSimplDTO : BaseDTO
{
    #region Auto
    #endregion

    #region Manual
  
    public string FullName { get; set; }
    public string Lineage { get; set; }
    public string FatherName { get; set; }
    public string SponsorName { get; set; }
    public bool IsSponsored { get; set; }
    public int Score { get; set; }

    #endregion

}
public class OrphanFormDTO : BaseFormDTO
{
    public Guid? FamilyId { get; set; }

    [Required, MaxLength(128)]
    public string FullName { get; set; }

    [Required]
    public DateTime Birthday { get; set; }

    [Required]
    public string Gender { get; set; }

    [Required, MaxLength(128)]
    public string Lineage { get; set; }

    [MaxLength(128)]
    public string? IllnessName { get; set; }

    public DateTime? IllnessDate { get; set; }

    [MaxLength(128)]
    public string? IllnessStatus { get; set; }

    [MaxLength(128)]
    public string? IllnessType { get; set; }

    [MaxLength(512)]
    public string? PreviousSurgeries { get; set; }

    [MaxLength(512)]
    public string? PermanentDisabilities { get; set; }

    public bool? IsHereditary { get; set; }

    [MaxLength(512)]
    public string? MedFollowUp { get; set; }

    public int? MedFollowUpCount { get; set; }

    public decimal? TotalAmount { get; set; }

    [MaxLength(128)]
    public string? MedSpecialty { get; set; }

    [MaxLength(1024)]
    public string? MedicalNotes { get; set; }

    [Required, MaxLength(128)]
    public string SchoolStatus { get; set; }

    [Required, MaxLength(128)]
    public string SchoolName { get; set; }

    [Required]
    public string SchoolType { get; set; }

    public decimal? SchoolFees { get; set; }

    [Required, MaxLength(128)]
    public string SchoolFeesSource { get; set; }

    [Required, MaxLength(128)]
    public string SchoolAddress { get; set; }

    [MaxLength(1024)]
    public string? SchoolNotes { get; set; }

    [MaxLength(128)]
    public string? TalentType { get; set; }

    [MaxLength(1024)]
    public string? TalentNotes { get; set; }

    [Required]
    public int Score { get; set; } = 0;

}

public class OrphanUpdateDTO : BaseUpdateDTO
{
    [Required]
    public Guid FamilyId { get; set; }

    [MaxLength(128)]
    public string? FullName { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Gender { get; set; }

    [MaxLength(128)]
    public string? Lineage { get; set; }

    [MaxLength(128)]
    public string? IllnessName { get; set; }

    public DateTime? IllnessDate { get; set; }

    [MaxLength(128)]
    public string? IllnessStatus { get; set; }

    [MaxLength(128)]
    public string? IllnessType { get; set; }

    [MaxLength(512)]
    public string? PreviousSurgeries { get; set; }

    [MaxLength(512)]
    public string? PermanentDisabilities { get; set; }

    public bool? IsHereditary { get; set; }

    [MaxLength(512)]
    public string? MedFollowUp { get; set; }

    public int? MedFollowUpCount { get; set; }

    public decimal? TotalAmount { get; set; }

    [MaxLength(128)]
    public string? MedSpecialty { get; set; }

    [MaxLength(1024)]
    public string? MedicalNotes { get; set; }

    [MaxLength(128)]
    public string? SchoolStatus { get; set; }

    [MaxLength(128)]
    public string? SchoolName { get; set; }


    public string? SchoolType { get; set; }

    public decimal? SchoolFees { get; set; }

    [MaxLength(128)]
    public string? SchoolFeesSource { get; set; }

    [MaxLength(128)]
    public string? SchoolAddress { get; set; }

    [MaxLength(1024)]
    public string? SchoolNotes { get; set; }

    [MaxLength(128)]
    public string? TalentType { get; set; }

    [MaxLength(1024)]
    public string? TalentNotes { get; set; }
    public int? Score { get; set; } = 0;
    public bool IsSponsored { get; set; } 
}

public class OrphanFilter : BaseFilter
{
    public string? FullName { get; set; }
    public DateTime? Birthday { get; set; }
    public int? Score { get; set; }
    public string? Gender { get; set; }
    public Guid? FamilyId { get; set; }
    public bool? IsSponsored { get; set; } 
}
