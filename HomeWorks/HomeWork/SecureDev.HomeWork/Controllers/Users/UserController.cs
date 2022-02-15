using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;

namespace SecureDev.HomeWork.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        //private readonly IUserRepository _repository;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "логгер всроен в UserController.");
            //_repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult UserRoom()
        {
            return View();
        }
    }
}
