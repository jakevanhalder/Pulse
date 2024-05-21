using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PulseWeb.Data;
using PulseWeb.Models;
using PulseWeb.Repository.IRepository;
using PulseWeb.Utility;

namespace PulseWeb.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = SD.Role_User)]
    public class BudgetController : Controller
    {
        private readonly IBudgetRepository _budgetRepository;

        public BudgetController(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        // GET: Budget
        public IActionResult Index(string view)
        {
            // Store the selected view in ViewBag for use in the view
            ViewBag.SelectedView = view ?? "In Progress"; // Default to In Progress

            List<BudgetItem> objBudgetList = _budgetRepository.GetAll().ToList();
            return View(objBudgetList);
        }

        // GET: BudgetItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BudgetItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Category,Title,Description,Amount,Date")] BudgetItem budgetItem)
        {
            if (ModelState.IsValid)
            {
                _budgetRepository.Add(budgetItem);
                _budgetRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(budgetItem);
        }

        // GET: BudgetItems/Edit/Id
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var budgetItem = _budgetRepository.Get(u => u.Id == id);
            if (budgetItem == null)
            {
                return NotFound();
            }
            return View(budgetItem);
        }

        // POST: BudgetItems/Edit/Id
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Category,Title,Description,Amount,Date")] BudgetItem budgetItem)
        {
            if (id != budgetItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _budgetRepository.Update(budgetItem);
                _budgetRepository.Save();
                TempData["success"] = "Budget updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(budgetItem);
        }

        // GET: BudgetItems/Delete/Id
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetItem = _budgetRepository.Get(u => u.Id == id);

            if (budgetItem == null)
            {
                return NotFound();
            }

            return View(budgetItem);
        }

        // POST: BudgetItems/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var budgetItem = _budgetRepository.Get(u => u.Id == id);
            if (budgetItem != null)
            {
                _budgetRepository.Remove(budgetItem);
            }

            _budgetRepository.Save();
            TempData["success"] = "Budget deleted";
            return RedirectToAction(nameof(Index));
        }
    }
}
