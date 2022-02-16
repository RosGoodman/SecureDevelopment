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

        public string MoveAction { get; set; }

        public SelectAndUseRobotsController(ILogger<SelectAndUseRobotsController> logger, IUserRepository repository)
        {

            _logger = logger;
            _logger.LogDebug(1, "логгер всроен в SelectAndUseRobotsController.");
            _repository = repository;
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> Index() 
        {
            var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Name));
            var user = await _repository.GetById(userId);

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
        public async Task<IActionResult> ChangeRobot(RobotTypes robotType)
        {
            int id = Convert.ToInt32(User.Identity.Name);
            int robotTypeIndex = Array.IndexOf(Enum.GetValues(robotType.GetType()), robotType);

            if (await _repository.UpdateAsync(id, robotTypeIndex)) return Redirect("/SelectAndUseRobots");
            return View("Не удалось сохранить изменения.");
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async void MoveRobot()
        {
            int userId = Convert.ToInt32(User.Identity.Name);
            var user = await _repository.GetById(userId);

            var robot = new GetterOfRobots()
                .GetRobotByName((RobotTypes)Enum.GetValues(typeof(RobotTypes)).GetValue(user.RobotId));
            MoveAction = robot.Move();
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
