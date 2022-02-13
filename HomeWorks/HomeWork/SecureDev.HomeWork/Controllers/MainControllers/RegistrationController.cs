using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureDev.HomeWork.DAL.Repositories;
using SecureDev.HomeWork.ViewModels;
using System.Security.Claims;

namespace SecureDev.HomeWork.Controllers
{
    [Authorize]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationRepository _repository;
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(IRegistrationRepository repository,  ILogger<RegistrationController> logger)
        {
            _repository = repository;
            _logger = logger;
            _logger.LogDebug(1, "логгер всроен в ProductController.");
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary> Страница регистрации. </summary>
        /// <param name="returnUrl"> URL для перенаправления. </param>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult Register(string returnUrl)
        {
            return View();
        }

        /// <summary> Регистрация пользователя. </summary>
        /// <param name="vm"> Модель данных для регистрации. </param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegistrationModel vm)
        {
            _logger.LogDebug(1, "Выполнение запроса регистрации пользователя.");

            if (vm.Password != vm.RepeatPassword)
                //перенаправление тут больше для пробы, ну и обновляет страницу при несовпадении
                return RedirectToAction("Register", "Registration");

            if (!ModelState.IsValid)
                return View(vm);

            //регистация с проверкой. Если не зарегистрировался, то обновление страницы
            if (!await _repository.TryRegisterAsync(vm)) return RedirectToAction("Register", "Registration");

            var claims = new List<Claim>();
            if (vm.Role == "User")
            {
                claims = new List<Claim> { new Claim(ClaimTypes.Role, "User") };
            }
            else if (vm.Role == "Administrator")
            {
                claims = new List<Claim> { new Claim(ClaimTypes.Role, "Administrator") };
            }
            else
            {
                claims = new List<Claim> { new Claim("Demo", "Demo") };
            }

            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookie", claimPrincipal);

            return Redirect("/Home");
        }
    }
}
