using System.ComponentModel.DataAnnotations;

namespace DeviceManagement.Models
{
    public enum DeviceStatus
    {
        [Display(Name = "In use")]
        InUse,

        [Display(Name = "Broken")]
        Broken,

        [Display(Name = "Under maintenance")]
        UnderMaintenance
    }
}