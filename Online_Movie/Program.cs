using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Online_Movie.Repository;
using Online_Movie.Controllers;
using Online_Movie.Models;
using Online_Movie.Areas;
using Microsoft.AspNetCore.Identity;
using Online_Movie.Data;
using Online_Movie.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Denpendency Injection
builder.Services.AddDbContext<MoviesContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesDB"));

});

builder.Services.AddDbContext<Online_MovieContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("Online_MovieContextConnection"));

});

builder.Services.AddDefaultIdentity<Online_MovieUser>(options => options.SignIn.RequireConfirmedAccount = false)
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<Online_MovieContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireUppercase = false;
});

//DI
builder.Services.AddTransient<IMovieReposistory, MovieReposistory>();
builder.Services.AddTransient<ICategoryReposistory, CategoryReposistory>();
builder.Services.AddTransient<IUserReposistory, UserRepository>();
//step 1
builder.Services.AddSession();
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
//step 2
app.UseSession();

app.MapAreaControllerRoute(
    name: "MyAreas",
    areaName: "Admin",
    pattern: "Admin/{controller}/{action=Index}/{id?}",
    defaults: new { controller = "Home", action = "Index"}
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();


