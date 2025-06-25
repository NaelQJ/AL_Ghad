namespace Moe.Core.Models.Entities;

public class Document : BaseEntity
{
    public Family Family { get; set; }
    public Guid? FamilyId { get; set; }

    public Orphan Orphan { get; set; }
    public Guid? OrphanId { get; set; }
    public string FilePath { get; set; }
}


public class Device:BaseEntity
{ 
    public Family Family { get; set; }
    public Guid FamilyId { get; set; }

    public string DevicePath { get; set; }
}

