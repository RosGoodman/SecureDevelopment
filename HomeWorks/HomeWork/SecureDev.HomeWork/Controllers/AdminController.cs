using Lesson1.SQL_Injecrion.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lesson1.SQL_Injecrion.Controllers;

[Authorize]
public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [AllowAnonymous]
    public IActionResult Login(string returnUrl)
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var claims = new List<Claim>
            {
                new Claim("Demo","Value")
            };
        var claimIdentity = new ClaimsIdentity(claims, "Cookie");
        var claimPrincipal = new ClaimsPrincipal(claimIdentity);
        await HttpContext.SignInAsync("Cookie", claimPrincipal);

        return Redirect(model.ReturnUrl);
    }

    public IActionResult LogOff()
    {
        HttpContext.SignOutAsync("Cookie");
        return Redirect("/Home/Index");
    }
}
