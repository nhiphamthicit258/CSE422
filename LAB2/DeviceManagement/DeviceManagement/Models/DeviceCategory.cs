using System.ComponentModel.DataAnnotations;

namespace DeviceManagement.Models
{
    public class DeviceCategory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
/*Id: Mã định danh của loại thiết bị.
[Required]: Bắt buộc nhập tên.
[StringLength(50)]: Tên tối đa 50 ký tự.
Name: Tên loại thiết bị, ví dụ Computer, Printer, Phone.
*/