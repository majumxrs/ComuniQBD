using ComuniQBD.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<Contexto> //Gabi
//   (options => options.UseSqlServer("Data Source=SP-1491023\\SQLSENAI;Initial Catalog = ComuniQBD;Integrated Security = True;TrustServerCertificate = True"));

//builder.Services.AddDbContext<Contexto> //Edu
//   (options => options.UseSqlServer("Data Source=SP-1491021\\SQLSENAI;Initial Catalog = ComuniQBD;Integrated Security = True;TrustServerCertificate = True"));

builder.Services.AddDbContext<Contexto> //Maju
   (options => options.UseSqlServer("Data Source=SP-1491028\\SQLSENAI;Initial Catalog = ComuniQBD;Integrated Security = True;TrustServerCertificate = True"));

/*builder.Services.AddDbContext<Contexto> //Rafa
    (options => options.UseSqlServer("Data Source=SP-1491022\\SQLSENAI;Initial Catalog = ComuniQBD;Integrated Security = True;TrustServerCertificate = True"));*/
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
