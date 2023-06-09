using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Online_Movie.Repository;
using Online_Movie.Controllers;
using Online_Movie.Models;
using Online_Movie.Areas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Denpendency Injection
builder.Services.AddDbContext<MoviesContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesDB"));

});

//DI
builder.Services.AddTransient<IMovieReposistory, MovieReposistory>();
builder.Services.AddTransient<ICategoryReposistory, CategoryReposistory>();
builder.Services.AddTransient<IUserReposistory, UserRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "MyAreas",
    areaName: "Admin",
    pattern: "Admin/{controller}/{action=Index}/{id?}",
    defaults: new { controller = "Home", action = "Index" }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


