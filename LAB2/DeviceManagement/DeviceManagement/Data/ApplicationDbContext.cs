using DeviceManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.Data
{
    public class ApplicationDbContext : DbContext //DbContext: Cầu nối giữa code C# và database.
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; } //DbSet<Device>: Đại diện cho bảng thiết bị.
        public DbSet<DeviceCategory> DeviceCategories { get; set; } //DbSet<DeviceCategory>: Đại diện cho bảng loại thiết bị.
        public DbSet<User> Users { get; set; } //DbSet<User>: Đại diện cho bảng người dùng.
    }
}
    