using Microsoft.EntityFrameworkCore;
using MyRazorProject.Models;  // Thêm namespace của các mô hình dữ liệu

namespace MyRazorProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor nhận chuỗi kết nối
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // Định nghĩa các DbSet cho các thực thể trong cơ sở dữ liệu
        public DbSet<AboutModel> AboutList { get; set; } = default!;

    }
}
