using SecureDev.HomeWork.DAL.Models;
using SecureDev.HomeWork.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SecureDev.HomeWork.ViewModels;

namespace SecureDev.HomeWork.Controllers
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
            ViewBag.Name = User.Identity.Name;
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary> Страница для отображения, что доступ закрыт. </summary>
        /// <returns></returns>
        public IActionResult AccessDenied()
        {
            return View();
        }

        /// <summary> Добавить данные о карте. </summary>
        /// <param name="newCard"> Экземпляр новой карты. </param>
        /// <param name="repository"> Репозиторий. </param>
        /// <returns></returns>
        public async Task<IActionResult> AddCardDataRquest(Card newCard, [FromServices] IRepository<Card> repository)
        {
            //скрыть Card за интерфейсом у меня не вышло

            if (!ValidationCard(newCard)) return View();

            var card = await repository.GetAsync(newCard);
            if (card == null)
            {
                repository.AddAsync(newCard);
                return View(newCard);
            }

            return View(card);
        }

        /// <summary> Проверка заполненности значений. </summary>
        /// <param name="newCard"> Новая карта. </param>
        /// <returns> false - данные не полные. </returns>
        private bool ValidationCard(Card newCard)
        {
            if (newCard.NumbCard == 0 || newCard.CVV_CVC == 0 || newCard.CardOwner == "") return false;
            return true;
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