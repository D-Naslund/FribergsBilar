using FribergsBilar.Data;
using FribergsBilar.Data.DataInterfaces;
using FribergsBilar.Services;
using FribergsBilar.Services.Interfaces;
using FribergsBilar.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace FribergsBilar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var conString = builder.Configuration.GetConnectionString("FribergCarsDB") ?? 
                throw new InvalidOperationException("Connection string 'FribergCarsDB'" + " not found.");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(conString));
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<IUser, UserRepository>();
            builder.Services.AddScoped<IUserService,UserService>();
            builder.Services.AddScoped<IBooking, BookingRepository>();
            builder.Services.AddScoped<IBookingService,BookingService>();
            builder.Services.AddScoped<ICar, CarRepository>();
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<IAdmin, AdminRepository>();
            builder.Services.AddScoped<IAdminService, AdminService>();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(1); 
                options.Cookie.HttpOnly = true; 
                options.Cookie.IsEssential = true; 
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
