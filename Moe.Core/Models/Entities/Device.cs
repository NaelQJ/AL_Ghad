using System.ComponentModel.DataAnnotations;

namespace Moe.Core.Models.Entities;

public class Device : BaseEntity
{
    #region One-To-N
    #endregion

    #region Functional
    #endregion

    #region Non-Functional
    [MaxLength(128)]
    public string Name { get; set; }
    #endregion

    #region Many-To-N
    public ICollection<FamilyDevice> FamilyDevices { get; set; } = new List<FamilyDevice>();    
    #endregion
}



public class FamilyDevice : BaseEntity
{
    public Family Family { get; set; }
    public Guid FamilyId { get; set; }
    

    public Device Device { get; set; }
    public Guid DeviceId { get; set; }
    

    public string DeviceImge { get; set; }
}


public class FamilyDeviceDTO 
{
    public Guid DeviceId { get; set; }
    public string DeviceImge { get; set; }
}