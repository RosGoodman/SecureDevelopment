using Common.Interfaces.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgramLogic;
using System.Security.Claims;

namespace SecureDev.HomeWork.Controllers
{
    [Authorize]
    public class SelectAndUseRobotsController : Controller
    {
        private readonly ILogger<SelectAndUseRobotsController> _logger;
        private readonly IUserRepository _repository;

        public SelectAndUseRobotsController(ILogger<SelectAndUseRobotsController> logger, IUserRepository repository)
        {

            _logger = logger;
            _logger.LogDebug(1, "логгер всроен в SelectAndUseRobotsController.");
            _repository = repository;
        }

        [Authorize(Roles = "User")]
        public IActionResult Index() 
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Name));
            var user = _repository.GetById(userId);

            RobotTypes robotType = 0;
            try
            {
                robotType = (RobotTypes)Enum.GetValues(typeof(RobotTypes)).GetValue(user.RobotId);
            }
            catch (Exception ex) { _logger.LogError(ex, "Ошибка при попытке получить тип робота."); }

            ViewBag.RobotsList = GetRobotsList();
            ViewBag.RobotName = new GetterOfRobots().GetRobotByName(robotType).Name;
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Create(RobotTypes robotType)
        {
            return View();
        }

        private List<RobotTypes> GetRobotsList()
        {
            var robotsTypes = new List<RobotTypes>();

            robotsTypes.Add(RobotTypes.EmptyRobotFrame);
            robotsTypes.Add(RobotTypes.CrawScrewdriverRobot);
            robotsTypes.Add(RobotTypes.FlyCleanerRobot);
            robotsTypes.Add(RobotTypes.RideHummerRobot);
            return robotsTypes;
        }
    }
}
