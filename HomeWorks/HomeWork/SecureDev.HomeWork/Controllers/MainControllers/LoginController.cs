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

        /// <summary> Страница ввода лоина и пароля. </summary>
        /// <param name="returnUrl"> URL для перенаправления. </param>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        /// <summary> Вход пользователя. </summary>
        /// <param name="model"> Модель с данными для входа. </param>
        /// <returns></returns>
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
            var claims = GetClaimsList(user);

            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookie", claimPrincipal);

            return Redirect(model.ReturnUrl);
        }

        /// <summary> Получить список клаймов в соответствии с ролью. </summary>
        /// <param name="user"> Авторизирующийся пользователь. </param>
        /// <returns> Список клаймов. </returns>
        private List<Claim> GetClaimsList(UserModel user)
        {
            if (user.Role == "User")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, "User")
                };
                return claims;
            }
            if (user.Role == "Administrator")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Administrator")
                };
                return claims;
            }
            return null;
        }

        /// <summary> Выход из аккаунта. </summary>
        /// <returns></returns>
        public IActionResult LogOff()
        {
            HttpContext.SignOutAsync("Cookie");
            return Redirect("/Home/Index");
        }
    }
}
