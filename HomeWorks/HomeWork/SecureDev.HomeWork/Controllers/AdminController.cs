using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureDev.HomeWork.Controllers;

[Authorize]
public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [Authorize(Roles = "Administrator")]
    public IActionResult Administrator()
    {
        return View();
    }
}
