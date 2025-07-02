using System.ComponentModel.DataAnnotations;

namespace Moe.Core.Models.DTOs;

public class DeviceDTO : BaseDTO
{
    #region Auto
    #endregion

    #region Manual
   
    public string Name { get; set; }
    #endregion
} 

public class DeviceFormDTO : BaseFormDTO
{
    [MaxLength(128)]
    [Required]
    public string Name { get; set; }
}

public class DeviceUpdateDTO : BaseUpdateDTO
{
    public string? Name { get; set; }
}

public class DeviceFilter : BaseFilter
{
}
