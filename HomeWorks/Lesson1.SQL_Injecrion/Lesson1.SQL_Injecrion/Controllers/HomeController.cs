using Lesson1.SQL_Injecrion.DAL.Models;
using Lesson1.SQL_Injecrion.Interfaces;
using Lesson1.SQL_Injecrion.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lesson1.SQL_Injecrion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> CardDataRequest(Card newCard, [FromServices] IRepository<Card> repository)
        {
            if (newCard.NumbCard == 0 || newCard.CVV_CVC == 0 || newCard.CardOwner == "") return View();

            var card = await repository.GetAsync(newCard);
            return View(card);
        }

        public async Task<IActionResult> CardDataInput()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}