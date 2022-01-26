using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureDev.HomeWork.DAL.Models;
using SecureDev.HomeWork.Interfaces;
using SecureDev.HomeWork.ViewModels;
using System.Security.Claims;

namespace SecureDev.HomeWork.Controllers
{
    [Authorize]
    public class RegistrationController : Controller
    {
        private readonly IRepository<IUserModel> _repository;
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(IRepository<IUserModel> repository,  ILogger<RegistrationController> logger)
        {
            _repository = repository;
            _logger = logger;
            _logger.LogDebug(1, "логгер всроен в ProductController.");
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(IRegistrationViewModel vm)
        {
            if(vm.Password != vm.RepeatPassword)
                //перенаправление тут больше для пробы, ну и обновляет страницу при несовпадении
                return RedirectToAction("Register", "Registration");

            if (!ModelState.IsValid) 
                return View(vm);

            if(!_repository.)

            var claims = new List<Claim>
            {
                new Claim("Demo","Value")
            };
            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookie", claimPrincipal);

            return Redirect(vm.ReturnUrl);
        }
    }
}
