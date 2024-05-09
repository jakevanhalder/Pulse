using Microsoft.AspNetCore.Mvc;
using PulseWeb.Models;
using PulseWeb.Repository.IRepository;
using System.Diagnostics;

namespace PulseWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGoalRepository _goalRepository;
        private readonly IToDoRepository _toDoRepository;
        private readonly IBudgetRepository _budgetRepository;

        public HomeController(ILogger<HomeController> logger, IGoalRepository goalRepository, IToDoRepository toDoRepository, IBudgetRepository budgetRepository)
        {
            _logger = logger;
            _goalRepository = goalRepository;
            _toDoRepository = toDoRepository;
            _budgetRepository = budgetRepository;
        }

        public IActionResult Index()
        {
            // Fetch data from repositories
            var goals = _goalRepository.GetAll();
            var toDo = _toDoRepository.GetAll();
            var budget = _budgetRepository.GetAll();

            // Create a view model to hold the data
            var viewModel = new HomeViewModel
            {
                Goals = goals,
                ToDoItems = toDo,
                BudgetItems = budget
            };

            return View(viewModel);
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
