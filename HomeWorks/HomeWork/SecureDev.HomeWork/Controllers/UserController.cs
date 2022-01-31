using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureDev.HomeWork.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult User()
        {
            return View();
        }
    }
}
