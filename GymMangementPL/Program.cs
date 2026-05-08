using GymMangementDAL.Data.Contexts;
using GymMangementDAL.Entities;
using GymMangementDAL.Repositories.Classes;
using GymMangementDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace GymMangementPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<GymDbContext>(options =>
            {
                //options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));//short hand for the above line
            });
            // Register the generic repository service
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IPlanRepository), typeof(PlanRepository));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
