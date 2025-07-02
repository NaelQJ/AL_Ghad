namespace Moe.Core.Models.Entities;

public class SponsorShip : BaseEntity
{
    #region One-To-N
    public Sponsor Sponsor { get; set; }
    public Guid SponsorId { get; set; }

    public Orphan Orphan { get; set; }
    public Guid? OrphanId { get; set; }

    public Family Family { get; set; }
    public Guid? FamilyId { get; set; }
    #endregion

    #region Functional
    public Status status { get; set; } = Status.Pending;


    public DateTime StartSpons { get; set; }
    public DateTime EndSpons { get; set; }
    #endregion

    #region Non-Functional
    #endregion

    #region Many-To-N
    #endregion

}
