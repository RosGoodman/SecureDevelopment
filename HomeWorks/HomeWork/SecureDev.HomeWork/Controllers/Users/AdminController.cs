using Common.Interfaces.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureDev.HomeWork.DAL.Models;

namespace SecureDev.HomeWork.Controllers;

[Authorize]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;
    private readonly IUserRepository _repository;

    public AdminController(ILogger<AdminController> logger, IUserRepository repository)
    {
        _logger = logger;
        _logger.LogDebug(1, "логгер всроен в AdminController.");
        _repository = repository;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Administrator()
    {
        ViewBag.allUsers = await _repository.GetAllAsync();

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> DeletingUser(UserModel user)
    {
        bool isDeleted = await _repository.DeleteAsync(user.Id);
        return Redirect("~/Admin/MainControllers/Administrator");
    }
}
