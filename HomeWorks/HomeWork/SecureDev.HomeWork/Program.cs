using SecureDev.HomeWork.DAL.Context;
using SecureDev.HomeWork.DAL.Repositories;
using SecureDev.HomeWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using SecureDev.HomeWork.DAL.Models;
using SecureDev.HomeWork.ViewModels;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

//����������� ���� � ��
services.AddDbContext<ContextDB>(opt => opt
    .UseSqlServer(builder.Configuration.GetConnectionString("Default")));
//����������� ����� ����������� � ����������
services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
services.AddScoped(typeof(IUserModel), typeof(UserModel));
//services.AddScoped(typeof(IRegistrationViewModel), typeof(RegistrationViewModel));
services.AddTransient<IRegistrationViewModel, RegistrationViewModel>();
services.AddScoped(typeof(IContextDB), typeof(ContextDB));
services.AddScoped(typeof(IRegistrationRepository), typeof(RegistrationRepository));


//����������� ����������� � ��������������
services.AddAuthentication("Cookie")
    .AddCookie("Cookie", config =>
    {
        config.LoginPath = "/Registration/Register";
    });
services.AddAuthorization();

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

//�������� ������������� ������������ ����������� � ��������������
//������ ���������� ����� app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// ��������� ��������.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
