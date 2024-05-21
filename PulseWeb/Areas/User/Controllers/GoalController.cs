using Microsoft.AspNetCore.Mvc;
using PulseWeb.Data;
using PulseWeb.Models;
using PulseWeb.Repository;
using PulseWeb.Repository.IRepository;

namespace PulseWeb.Areas.User.Controllers
{
    [Area("User")]
    public class GoalController : Controller
    {
        private readonly IGoalRepository _goalRepository;

        public GoalController(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public IActionResult Index(string view)
        {
            // Store the selected view in ViewBag for use in the view
            ViewBag.SelectedView = view ?? "In Progress"; // Default to In Progress

            List<Goal> objGoalList = _goalRepository.GetAll().ToList();
            return View(objGoalList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Goal obj)
        {
            if (ModelState.IsValid)
            {
                _goalRepository.Add(obj);
                _goalRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var goalFromDb = _goalRepository.Get(u => u.Id == id);

            if (goalFromDb == null)
            {
                return NotFound();
            }

            return View(goalFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Goal obj)
        {
            if (ModelState.IsValid)
            {
                _goalRepository.Update(obj);
                _goalRepository.Save();
                TempData["success"] = "Goal updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var goalFromDb = _goalRepository.Get(u => u.Id == id);

            if (goalFromDb == null)
            {
                return NotFound();
            }

            return View(goalFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _goalRepository.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _goalRepository.Remove(obj);
            _goalRepository.Save();
            TempData["success"] = "Goal deleted";
            return RedirectToAction("Index");
        }
    }
}
