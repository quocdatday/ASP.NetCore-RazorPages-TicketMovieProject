using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ASPNetCoreRazorPage_TicketMovie.Models
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }
        //public DbSet<Banner> Banners { get; set; }
        //public DbSet<Cart> Carts { get; set; }
        //public DbSet<CartDetail> CartDetails { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderDetail> OrderDetails { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Review> Reviews { get; set; }
        //public DbSet<Setting> Settings { get; set; }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{

        //    base.OnModelCreating(builder);
        //    // Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
        //    // tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
        //    // Đoạn mã sau chạy khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố đó
        //    foreach (var entityType in builder.Model.GetEntityTypes())
        //    {
        //        var tableName = entityType.GetTableName();
        //        if (tableName!.StartsWith("AspNet"))
        //        {
        //            entityType.SetTableName(tableName.Substring(6));
        //        }
        //    }
        //    var admin = new IdentityRole("admin");
        //    admin.NormalizedName = "admin";
        //    var user = new IdentityRole("user");
        //    user.NormalizedName = "user";
        //    builder.Entity<IdentityRole>().HasData(admin, user);
        //}
    }
}
