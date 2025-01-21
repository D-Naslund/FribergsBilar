using FribergsBilar.Data;
using FribergsBilar.Repositories;
using FribergsBilar.Services;
using FribergsBilar.Services.Interfaces;
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
            builder.Services.AddScoped<IUser, UserRepository>();
            builder.Services.AddScoped<IAuthService,AuthService>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
