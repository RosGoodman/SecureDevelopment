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

        public async Task<IActionResult> CardDataRequest(long numbCard, int cvv_cvc, string cardOwner, DateTime validaty, [FromServices] IRepository<Card> repository)
        {
            if (numbCard == 0 || cvv_cvc == 0 || cardOwner == "") return View();

            var card = await repository.GetAsync(new Card() { NumbCard = numbCard, CardOwner = cardOwner, CVV_CVC = cvv_cvc, Validity = validaty });
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