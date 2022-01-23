using Lesson1.SQL_Injecrion.DAL.Models;
using Lesson1.SQL_Injecrion.Interfaces;
using Lesson1.SQL_Injecrion.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Lesson1.SQL_Injecrion.Controllers
{
    /// <summary> Контроллер домашней страницы. </summary>
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

        /// <summary> Добавить данные о карте. </summary>
        /// <param name="newCard"> Экземпляр новой карты. </param>
        /// <param name="repository"> Репозиторий. </param>
        /// <returns></returns>
        public async Task<IActionResult> AddCardDataRquest(Card newCard, [FromServices] IRepository<Card> repository)
        {
            if (newCard.NumbCard == 0 || newCard.CVV_CVC == 0 || newCard.CardOwner == "") return View();

            //простая проверка допустимых символов
            if(CheckSimbols(newCard)) return View("simbols");

            var card = await repository.GetAsync(newCard);
            if(card == null)
            {
                repository.AddAsync(newCard);
                return View(newCard);
            }

            return View(card);
        }

        /// <summary> Проверить на запрещенные символы. </summary>
        /// <param name="card"> Экземпляр класса Card. </param>
        /// <returns> true - запрещенные в наличии.</returns>
        private bool CheckSimbols(Card card)
        {
            if(!Regex.IsMatch(card.NumbCard.ToString(), @"^[a-zA-Z0-9_]+$")) return true;
            if (!Regex.IsMatch(card.CardOwner, @"^[a-zA-Z0-9_ ]+$")) return true;
            if (!Regex.IsMatch(card.CVV_CVC.ToString(), @"^[a-zA-Z0-9_]+$")) return true;
            if (!Regex.IsMatch(card.Validity.ToString(), @"^[a-zA-Z0-9_.: ]+$")) return true;
            return false;
        }

        /// <summary> Отобразить введенные данные. </summary>
        /// <returns></returns>
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