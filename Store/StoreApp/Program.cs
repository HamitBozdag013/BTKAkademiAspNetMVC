using System.Net;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Pages;
using Entities.Models;
using StoreApp.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Bu service 'i RepositoryContext 'i controller larda new leyip Dependency Injection yapabilmek için yazıyoruz.
builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlConnection"),
    b=>b.MigrationsAssembly("StoreApp"));
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options=>{
    options.Cookie.Name="StoreApp.Session";
    options.IdleTimeout=TimeSpan.FromMinutes(10);
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IRepositoryManager,RepositoryManager>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<Cart>(c=>SessionCart.GetCart(c));

builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

app.UseStaticFiles(); //Uygulamamızın static dosyalarda kullanabileceğini belirttik.
app.UseSession();
app.UseHttpsRedirection();
app.UseRouting();


// app.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}"); Bu şekilde de alttaki şekilde de kullanılabilir.

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

/*Projeme Admin işlmeleri için yeni bir alan(area) eklediğim için artık birden fazla endpoints 'im var. Bu yüzden UseEndpoints yapısını kullanarak
üstteki kodu aşağıdaki şekilde refactoring ediyorum.*/

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapRazorPages();

});


app.Run();

