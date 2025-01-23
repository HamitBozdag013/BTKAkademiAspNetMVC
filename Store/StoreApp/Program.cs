using Microsoft.EntityFrameworkCore;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//Bu service 'i RepositoryContext 'i controller larda new leyip Dependency Injection yapabilmek için yazıyoruz.
builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlConnection"));
});

// builder.Services.AddDbContext<RepositoryContext>(options =>
// {
//     options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"));
// });

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();
app.UseRouting();

// app.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}"); Bu şekilde de alttaki şekilde de kullanılabilir.

app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}");

app.Run();
