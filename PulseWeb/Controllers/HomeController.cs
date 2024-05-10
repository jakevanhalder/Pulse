using Microsoft.AspNetCore.Mvc;
using PulseWeb.Models;
using PulseWeb.Repository;
using PulseWeb.Repository.IRepository;
using System.Diagnostics;
using System.Globalization;

namespace PulseWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGoalRepository _goalRepository;
        private readonly IToDoRepository _toDoRepository;
        private readonly IBudgetRepository _budgetRepository;
        private readonly CalendarManager _calendarManager;

        public HomeController(ILogger<HomeController> logger, IGoalRepository goalRepository, IToDoRepository toDoRepository, IBudgetRepository budgetRepository, CalendarManager calendarManager)
        {
            _logger = logger;
            _goalRepository = goalRepository;
            _toDoRepository = toDoRepository;
            _budgetRepository = budgetRepository;
            _calendarManager = calendarManager;
        }

        public IActionResult Index()
        {
            // Fetch data from repositories
            var goals = _goalRepository.GetAll();
            var toDo = _toDoRepository.GetAll();
            var budget = _budgetRepository.GetAll();

            // calendar
            var calendar = _calendarManager.GetCalender(DateTime.Now.Month, DateTime.Now.Year);

            // Create a view model to hold the data
            var viewModel = new HomeViewModel
            {
                Goals = goals,
                ToDoItems = toDo,
                BudgetItems = budget,
                Calendar = calendar
            };

            return View(viewModel);
        }

        //for ajax request
        public ActionResult AsyncUpdateCalender(int month, int year)
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                var calendar = _calendarManager.GetCalender(month, year);
                return Json(calendar);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
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
