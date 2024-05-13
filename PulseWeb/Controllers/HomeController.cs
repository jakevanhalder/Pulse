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

        public HomeController(ILogger<HomeController> logger, IGoalRepository goalRepository, IToDoRepository toDoRepository, IBudgetRepository budgetRepository)
        {
            _logger = logger;
            _goalRepository = goalRepository;
            _toDoRepository = toDoRepository;
            _budgetRepository = budgetRepository;
        }

        public IActionResult Index()
        {
            // Get today's date
            DateTime today = DateTime.Today;

            // Calculate the start and end dates of the current week (Sunday to Monday)
            DateTime sunday = today.AddDays(-(int)today.DayOfWeek);      
            DateTime saturday = sunday.AddDays(6);

            // Retrieve upcoming goals, todos, and budgets for the current week
            var upcomingGoals = _goalRepository.GetAll().Where(g => g.DueDate >= sunday && g.DueDate <= saturday);
            var upcomingTodos = _toDoRepository.GetAll().Where(t => t.DueDate >= sunday && t.DueDate <= saturday);
            var upcomingBudgets = _budgetRepository.GetAll().Where(b => b.Date >= sunday && b.Date <= saturday);

            // Map the data to UpcomingItem objects
            var upcomingItems = new List<UpcomingItem>();
            upcomingItems.AddRange(upcomingGoals.Select(g => new UpcomingItem { Type = "Goal", Name = g.Title, DueTime = g.DueTime, DueDate = g.DueDate }));
            upcomingItems.AddRange(upcomingTodos.Select(t => new UpcomingItem { Type = "ToDo", Name = t.Title, DueTime = t.DueTime, DueDate = t.DueDate }));
            upcomingItems.AddRange(upcomingBudgets.Select(b => new UpcomingItem { Type = "Budget", Name = b.Title, DueTime = b.Time, DueDate = b.Date }));

            // Fetch data from repositories
            var goals = _goalRepository.GetAll();
            var toDo = _toDoRepository.GetAll();
            var budget = _budgetRepository.GetAll();

            // Create a view model to hold the data
            var viewModel = new HomeViewModel
            {
                Goals = goals,
                ToDoItems = toDo,
                BudgetItems = budget,
                UpcomingItems = upcomingItems
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
