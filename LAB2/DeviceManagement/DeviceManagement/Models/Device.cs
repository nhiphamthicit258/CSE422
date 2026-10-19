using System.ComponentModel.DataAnnotations;

namespace DeviceManagement.Models
{
    public class Device
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Device name is required.")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Device code is required.")]
        [StringLength(30)]
        public string Code { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
        public int DeviceCategoryId { get; set; }

        public DeviceCategory? DeviceCategory { get; set; }

        public DeviceStatus Status { get; set; } = DeviceStatus.InUse;

        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; } = DateTime.Today;
    }
}