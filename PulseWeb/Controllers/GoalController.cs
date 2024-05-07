using Microsoft.AspNetCore.Mvc;
using PulseWeb.Data;
using PulseWeb.Models;

namespace PulseWeb.Controllers
{
    public class GoalController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GoalController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Goal> objGoalList = _db.Goals;
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
                _db.Goals.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Goal created successfully";
                return RedirectToAction("Index");
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
            var goalFromDb = _db.Goals.Find(id);

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
                _db.Goals.Update(obj);
                _db.SaveChanges();
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
            var goalFromDb = _db.Goals.Find(id);

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
            var obj = _db.Goals.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Goals.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Goal deleted";
            return RedirectToAction("Index");
        }
    }
}
