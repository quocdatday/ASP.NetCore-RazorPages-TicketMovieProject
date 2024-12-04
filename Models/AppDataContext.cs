using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ASPNetCoreRazorPage_TicketMovie.Models
{
    public class AppDataContext : IdentityDbContext<UserOA>
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            // Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
            // tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
            // Đoạn mã sau khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố AspNet
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName!.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";
            var staff = new IdentityRole("staff");
            staff.NormalizedName = "staff";
            var user = new IdentityRole("user");
            user.NormalizedName = "user";
            builder.Entity<IdentityRole>().HasData(admin, staff, user);
        }
    }
}
