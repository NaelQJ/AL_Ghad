using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moe.Core.Models.Entities;

public class Family : BaseEntity
{
    #region One-To-N
    #endregion

    #region Functional
    public bool IsActive { get; set; } = false; 
    public bool IsSponsored { get; set; } = false;
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
    public string? SecondDeceasedName { get; set; }

    [Range(1, int.MaxValue)]
    public int OrphanCount { get; set; }



    [MaxLength(128)]
    public string MotherName { get; set; }

    [MaxLength(128)]
    public string MotherStudy { get; set; }

    [MaxLength(128)]
    public string MotherJop { get; set; }

    [MaxLength(16)]
    public string MotherPhone { get; set; }



    [MaxLength(128)]
    public string CurrentAddress { get; set; }

    [MaxLength(128)]
    public string CurrentFullAddress { get; set; }

    [MaxLength(128)]
    public string CurrentHousingType { get; set; }
    public int CurrentRoomCount { get; set; }
    public decimal? CurrentRentAmount { get; set; }




    [MaxLength(128)]
    public string PreviousAddress { get; set; }

    [MaxLength(128)]
    public string PreviousFullAddress { get; set; }

    [MaxLength(128)]
    public string PreviousHousingType { get; set; }
    public int PreviousRoomCount { get; set; }

    [MaxLength(128)]
    public string NearestLandmark { get; set; }


    [Range(10, 1000000)]
    public decimal Totalincome { get; set; }

    [MaxLength(128)]
    public string? Retirement { get; set; }

    [MaxLength(128)]
    public string? Assistance { get; set; }

    [MaxLength(128)]
    public string? Welfare { get; set; }

    [MaxLength(128)]
    public string? FamilyProject { get; set; }
    public int WorkingCount { get; set; }
   



    [MaxLength(128)]
    public string? ProjectType { get; set; }
    public bool? CanDevelopProject { get; set; }
    public bool? CanStartNewProject { get; set; }
    public decimal? ProposedBudget { get; set; }

    [MaxLength(1024)]
    public string Notes { get; set; }

    public int? Score { get; set; } = 0;

    #endregion

    #region Many-To-N
    public ICollection<Orphan> Orphans { get; set; } = new List<Orphan>();
    public ICollection<Document> Documents { get; set; } = new List<Document>();
    public ICollection<Device> Devices { get; set; } = new List<Device>();
    public ICollection<SponsorShip> SponsorShips { get; set; } = new List<SponsorShip>();
    public ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
    #endregion

}
