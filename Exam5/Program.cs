using Exam5.Business.Profiles;
using Exam5.Business.Services.Implements;
using Exam5.Business.Services.Interfaces;
using Exam5.DAL.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Exam5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<Exam5DbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"));
            }).AddIdentity<IdentityUser, IdentityRole>(opt =>
            {
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-.";
                opt.User.RequireUniqueEmail = true;

                opt.SignIn.RequireConfirmedPhoneNumber = false;
                opt.SignIn.RequireConfirmedEmail = false;
                opt.SignIn.RequireConfirmedAccount = false;

                opt.Password.RequireNonAlphanumeric = false;

            }).AddDefaultTokenProviders().AddEntityFrameworkStores<Exam5DbContext>();

            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();

            builder.Services.AddScoped<IInstructorService, InstructorService>();
            builder.Services.AddScoped<IAuthService, AuthService>();


            builder.Services.AddAutoMapper(opt =>
            {
                opt.AddProfile(new InstructorMappingProfile(builder.Environment.WebRootPath));
            });

            builder.Services.ConfigureApplicationCookie(opt =>
            {
                opt.AccessDeniedPath = "/auth/AccessDeniedPath";
                opt.LogoutPath = "/auth/Logout";
                opt.LoginPath = "/auth/Login";

                opt.Cookie.Name = "IdentityCookie";
                opt.ExpireTimeSpan = TimeSpan.FromDays(1);

                opt.SlidingExpiration = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Instructor}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}