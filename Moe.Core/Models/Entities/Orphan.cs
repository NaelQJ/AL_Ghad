using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Moe.Core.Models.Entities;

public class Orphan : BaseEntity
{
    #region One-To-N
    [DeleteBehavior(DeleteBehavior.SetNull)]
    public Family Family { get; set; }
    public Guid? FamilyId { get; set; }
    #endregion

    #region Functional
    public bool IsSponsored { get; set; } = false;
    #endregion

    #region Non-Functional

    [MaxLength(128)]
    public string FullName { get; set; }

    public DateTime Birthday { get; set; }

    public string Gender { get; set; }

    [MaxLength(128)]
    public string Lineage { get; set; }

    [MaxLength(1024)]
    public string Details { get; set; }



    [MaxLength(128)]
    public string? IllnessName { get; set; }

    public DateTime? IllnessDate { get; set; }

    [MaxLength(128)]
    public string? IllnessStatus { get; set; } // طارئ أو باردة

    [MaxLength(128)]
    public string? IllnessType { get; set; }

    [MaxLength(512)]
    public string? PreviousSurgeries { get; set; } // العمليات السابقة 

    [MaxLength(512)]
    public string? PermanentDisabilities { get; set; } // العاهات المستديمة

    public bool? IsHereditary { get; set; } // هل المرض وراثي

    [MaxLength(512)]
    public string? MedFollowUp { get; set; } // الادوية والمراجعة 

    public int? MedFollowUpCount { get; set; } // عدد مرات المراجعة

    public decimal? TotalAmount { get; set; } // المبلغ الكلي للعلاج

    [MaxLength(128)]
    public string? MedSpecialty { get; set; } // تخصص الطبي

    [MaxLength(1024)]
    public string? MedicalNotes { get; set; }




    [MaxLength(128)]
    public string SchoolStatus { get; set; }
    [MaxLength(128)]
    public string SchoolName { get; set; }

    public string SchoolType { get; set; }

    public decimal? SchoolFees { get; set; } 

    [MaxLength(128)]
    public string SchoolFeesSource { get; set; }

    [MaxLength(128)]
    public string SchoolAddress { get; set; }

    [MaxLength(1024)]
    public string? SchoolNotes { get; set; }




    [MaxLength(128)]
    public string? TalentType { get; set; }

    [MaxLength(1024)]
    public string? TalentNotes { get; set; }



    public int Score { get; set; } = 0;
    #endregion

    #region Many-To-N
    public ICollection<Document> Documents { get; set; } = new List<Document>();
    public ICollection<SponsorShip> SponsorShips { get; set; } = new List<SponsorShip>();
    #endregion
}



