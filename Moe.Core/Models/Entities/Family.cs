using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moe.Core.Models.Entities;

public class Family : BaseEntity
{
    #region One-To-N
    #endregion

    #region Functional
    public Status Status { get; set; } = Status.Pending;
    #endregion

    #region Non-Functional

    [MaxLength(128)]
    public string FatherName { get; set; }

    [MaxLength(128)]
    public string DeathCause { get; set; }

    public DateTime DeathDate { get; set; }

    [MaxLength(128)]
    public string FatherJob { get; set; }

    [MaxLength(128)]
    public string SecondDeceasedName { get; set; }


    
    [MaxLength(128)]
    public string MotherName { get; set; }

    [MaxLength(128)]
    public string MotherStudy { get; set; }

    [MaxLength(128)]
    public string MotherJop { get; set; }

    [MaxLength(16)]
    public string MotherPhone { get; set; }


    [MaxLength(64)]
    public string CurrentAddressRegion { get; set; }

    [MaxLength(32)]
    public string CurrentHousingType { get; set; }

    public int? CurrentRoomCount { get; set; }

    [MaxLength(256)]
    public string CurrentFullAddress { get; set; }

    public decimal CurrentRentAmount { get; set; }

    [MaxLength(128)]
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
    public bool CanDevelopProject { get; set; }
    public bool CanStartNewProject { get; set; }
    public decimal? ProposedBudget { get; set; }

    [MaxLength(1024)]
    public string? Notes { get; set; }

    public int Score { get; set; } = 0 ;

    #endregion

    #region Many-To-N
    public ICollection<Orphan> Orphans { get; set; } = new List<Orphan>();
    public ICollection<Document> Documents { get; set; } = new List<Document>();
    public ICollection<Device> Devices { get; set; } = new List<Device>();
    #endregion

}
