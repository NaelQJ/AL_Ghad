using System.ComponentModel.DataAnnotations;

namespace Moe.Core.Models.DTOs;

public class OrphanDTO : BaseDTO
{
    #region Auto
    #endregion

    #region Manual
    public Guid FamilyId { get; set; }
    public int Score { get; set; }
    public bool IsSponsored { get; set; }
    public string Details { get; set; }
    public GeneralInfoDTO General { get; set; } = new();
    public MedicalInfoDTO Medical { get; set; } = new();
    public SchoolInfoDTO School { get; set; } = new();
    public TalentInfoDTO Talent { get; set; } = new();
  
    public List<string> Documents { get; set; }
    

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
    [Required]
    public Guid FamilyId { get; set; }
    public GeneralInfoDTO General { get; set; } = new();
    public MedicalInfoDTO Medical { get; set; } = new();
    public SchoolInfoDTO School { get; set; } = new();
    public TalentInfoDTO Talent { get; set; } = new();

    [Required,MaxLength(1024)]
    public string Details { get; set; }

    public ICollection<string> Documents { get; set; } = new List<string>();



}
public class GeneralInfoDTO
{
    [Required, MaxLength(128)]
    public string FullName { get; set; }

    [Required]
    public DateTime Birthday { get; set; }

    [Required]
    public string Gender { get; set; }

    [Required, MaxLength(128)]
    public string Lineage { get; set; }

}
public class MedicalInfoDTO
{
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
}
public class SchoolInfoDTO
{
    [MaxLength(128)]
    [Required]
    public string SchoolStatus { get; set; }

    [MaxLength(128)]
    [Required]
    public string SchoolName { get; set; }

    [Required, MaxLength(128)]
    public string SchoolType { get; set; }

    [Range(1, double.MaxValue)]
    public decimal? SchoolFees { get; set; }

    [MaxLength(128)]
    [Required]
    public string SchoolFeesSource { get; set; }

    [MaxLength(128)]
    [Required]
    public string SchoolAddress { get; set; }

    [MaxLength(1024)]
    public string? SchoolNotes { get; set; }
}
public class TalentInfoDTO
{
    [MaxLength(128)]
    public string? TalentType { get; set; }

    [MaxLength(1024)]
    public string? TalentNotes { get; set; }
}




public class OrphanUpdateDTO : BaseUpdateDTO
{

    public bool? IsSponsored { get; set; }
    public Guid? FamilyId { get; set; }
    public GeneralInfoUpdateDTO General { get; set; } = new();
    public MedicalInfoUpdateDTO Medical { get; set; } = new();
    public SchoolInfoUpdateDTO School { get; set; } = new();
    public TalentInfoUpdateDTO Talent { get; set; } = new();

    public string? Details { get; set; }

    public ICollection<string>? Documents { get; set; } = new List<string>();
   
}
public class GeneralInfoUpdateDTO
{
    public string? FullName { get; set; }
    public DateTime? Birthday { get; set; }
    public string? Gender { get; set; }
    public string? Lineage { get; set; }

}
public class MedicalInfoUpdateDTO
{
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
}
public class SchoolInfoUpdateDTO
{
    [MaxLength(128)]
    public string? SchoolStatus { get; set; }

    [MaxLength(128)]
  
    public string? SchoolName { get; set; }

    [MaxLength(128)]
    public string? SchoolType { get; set; }

    [Range(1, double.MaxValue)]
    public decimal? SchoolFees { get; set; }

    [MaxLength(128)]

    public string? SchoolFeesSource { get; set; }

    [MaxLength(128)]
    public string? SchoolAddress { get; set; }

    [MaxLength(1024)]
    public string? SchoolNotes { get; set; }
}
public class TalentInfoUpdateDTO
{
    [MaxLength(128)]
    public string? TalentType { get; set; }

    [MaxLength(1024)]
    public string? TalentNotes { get; set; }
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
