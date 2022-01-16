using Lesson1.SQL_Injecrion.DAL.Context;
using Lesson1.SQL_Injecrion.DAL.Repositories;
using Lesson1.SQL_Injecrion.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

//регистрация пути к БД
services.AddDbContext<CardDB>(opt => opt
    .UseSqlServer(builder.Configuration.GetConnectionString("Default")));
//регистрация связи репозитория и интерфейса
services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
