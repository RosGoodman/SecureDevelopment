using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureDev.HomeWork.DAL.Models;
using SecureDev.HomeWork.DAL.Repositories;
using SecureDev.HomeWork.ViewModels;
using System.Security.Claims;

namespace SecureDev.HomeWork.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginRepository _repository;

        public LoginController(ILoginRepository repository, ILogger<LoginController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "логгер всроен в LoginController.");
            _repository = repository;
        }

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
            if (model.ReturnUrl is null) model.ReturnUrl = "/home";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UserModel user = await _repository.ChekUserIdDB(model);

            //переадресация, если нет подходящей роли.
            if (user == null)
            {
                return Redirect(model.ReturnUrl);
            }

            //получение клаймов в соответствии с ролями
            var claims = GetClaimsList(user, model);

            

            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookie", claimPrincipal);

            return Redirect(model.ReturnUrl);
        }

        private List<Claim> GetClaimsList(UserModel user, LoginViewModel model)
        {
            if (user.Role == "User")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    new Claim(ClaimTypes.Role, "User")
                };
                return claims;
            }
            if (user.Role == "Administrator")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    new Claim(ClaimTypes.Role, "Administrator")
                };
                return claims;
            }
            return null;
        }

        public IActionResult LogOff()
        {
            HttpContext.SignOutAsync("Cookie");
            return Redirect("/Home/Index");
        }
    }
}
