using ASPNetCoreRazorPage_TicketMovie.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreRazorPage_TicketMovie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Chấp nhận mọi IP 
            builder.WebHost.UseUrls("https://0.0.0.0:7096");

            // Add services to the container.
            builder.Services.AddRazorPages();

            //Thêm dịch vụ API Gmail
            builder.Services.AddSingleton<GmailAPI>();

            // Kết nối tới Database
            builder.Services.AddDbContext<AppDataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MovieTicket"));
            });

            builder.Services.AddDefaultIdentity<UserOA>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDataContext>();

            // Thêm dịch vụ bảo mật CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()  // Cho phép mọi domain
                          .AllowAnyMethod()  // Cho phép mọi HTTP method (GET, POST, PUT, DELETE, ...)
                          .AllowAnyHeader(); // Cho phép mọi header
                });
            });

            //Ràng buộc khi đăng kí tài khoản
            builder.Services.Configure<IdentityOptions>(options =>
            {
                //Thiết lập về Password
                options.Password.RequireDigit = false; // Không bắt phải có số
                options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
                options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
                options.Password.RequireUppercase = false; // Không bắt buộc chữ in
                options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
                options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

                //Cấu hình Lockout - khóa user
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30); // Khóa 30 phút
                options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
                options.Lockout.AllowedForNewUsers = true;

                //Cấu hình về User.
                options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;  // Email là duy nhất

                //Cấu hình đăng nhập.
                options.SignIn.RequireConfirmedEmail = false;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại
            });

            // Tăng giới hạn form
            builder.Services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = 2000; // Số lượng giá trị cho phép lớn hơn 1024
                options.MultipartBodyLengthLimit = 268435456; // Tăng kích thước tối đa của body (256MB)
            });

            // Tăng giới hạn kích thước yêu cầu (request size limits)
            builder.Services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = 268435456; // Tăng kích thước tối đa của body (256MB)
            });
            builder.Services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = 268435456; // Tăng kích thước tối đa của body (256MB)
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("AllowSpecificOrigin");

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
