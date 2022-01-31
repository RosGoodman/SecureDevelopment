using SecureDev.HomeWork.DAL.Context;
using SecureDev.HomeWork.DAL.Repositories;
using SecureDev.HomeWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using SecureDev.HomeWork.DAL.Models;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

//регистрация пути к БД
services.AddDbContext<ContextDB>(opt => opt
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

//регистрация связи репозитория и интерфейса
services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
services.AddScoped(typeof(IUserModel), typeof(UserModel));
services.AddScoped(typeof(IContextDB), typeof(ContextDB));
services.AddScoped(typeof(IRegistrationRepository), typeof(RegistrationRepository));
services.AddScoped(typeof(ILoginRepository), typeof(LoginRepository));


//подключение авторизации и аутентификации
services.AddAuthentication("Cookie")
    .AddCookie("Cookie", config =>
    {
        //переадрисация, если не авторизован
        config.LoginPath = "/Login/Login";
        config.AccessDeniedPath = "/Home/AccessDenied";
    });

services.AddAuthorization(options =>
{
    options.AddPolicy("Administrator", builder =>
    {
        builder.RequireClaim(ClaimTypes.Role, "Administrator");
    });
    options.AddPolicy("User", builder =>
    {
        builder.RequireClaim(ClaimTypes.Role, "User");
    });
});

// Add services to the container.
services.AddControllersWithViews();

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

//указание использования подключенных авторизации и аутентификации
//должны находиться после app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Начальная страница.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
