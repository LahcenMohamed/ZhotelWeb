
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ZhotelWeb.Repositories;
using ZhotelWeb.Repositories.DataHalper;
using ZHotelWeb.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<ZHotelDbContext>(options => {
            options.UseSqlServer(builder.Configuration.GetConnectionString("ZHotelDbConnection"));
        });
        builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<ZHotelDbContext>();
        builder.Services.AddScoped<ICustomerHalper, CustomerRepo>();
        builder.Services.AddScoped<IStaffHalper, StaffRepo>();
        builder.Services.AddScoped<IServiceHalper, ServiceRepo>();
        builder.Services.AddScoped<IReviewHalper, ReviewRepo>();
        builder.Services.AddScoped<IRoomHalper, RoomRepo>();
        builder.Services.AddScoped<IReservationHalper, ReservationRepo>();
        builder.Services.AddRazorPages();
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            options.AddPolicy("User", policy => policy.RequireRole("User"));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapRazorPages();

        app.MapControllerRoute(
            name: "default",
            //pattern: "{Area =Identity}/{controller=Account}/{action=Login}/{id?}");
            pattern: "{controller=HomeUser}/{action=Index}/{id?}");

        app.Run();
    }
}