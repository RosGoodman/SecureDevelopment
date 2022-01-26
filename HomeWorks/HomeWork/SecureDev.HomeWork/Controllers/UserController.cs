using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureDev.HomeWork.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
    }
}
