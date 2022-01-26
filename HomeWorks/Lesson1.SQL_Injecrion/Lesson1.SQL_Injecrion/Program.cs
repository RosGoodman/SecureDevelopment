using Lesson1.SQL_Injecrion.DAL.Context;
using Lesson1.SQL_Injecrion.DAL.Repositories;
using Lesson1.SQL_Injecrion.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

//����������� ���� � ��
services.AddDbContext<CardDB>(opt => opt
    .UseSqlServer(builder.Configuration.GetConnectionString("Default")));
//����������� ����� ����������� � ����������
services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));


//����������� ����������� � ��������������
services.AddAuthentication("Cookie")
    .AddCookie("Cookie", config =>
    {
        config.LoginPath = "/Admin/Login";
    });
services.AddAuthorization();

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

//�������� ������������� ������������ ����������� � ��������������
//������ ���������� ����� app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// ��������� ��������.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
