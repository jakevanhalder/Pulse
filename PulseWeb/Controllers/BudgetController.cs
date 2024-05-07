using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PulseWeb.Data;
using PulseWeb.Models;

namespace PulseWeb.Controllers
{
    public class BudgetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BudgetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Budget
        public IActionResult Index()
        {
            IEnumerable<BudgetItem> objBudgetList = _context.Budgets;
            return View(objBudgetList);
        }

        // GET: BudgetItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetItem = await _context.Budgets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (budgetItem == null)
            {
                return NotFound();
            }

            return View(budgetItem);
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
        public async Task<IActionResult> Create([Bind("Id,Category,Title,Description,Amount,Date")] BudgetItem budgetItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(budgetItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(budgetItem);
        }

        // GET: BudgetItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetItem = await _context.Budgets.FindAsync(id);
            if (budgetItem == null)
            {
                return NotFound();
            }
            return View(budgetItem);
        }

        // POST: BudgetItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Category,Title,Description,Amount,Date")] BudgetItem budgetItem)
        {
            if (id != budgetItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(budgetItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BudgetItemExists(budgetItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(budgetItem);
        }

        // GET: BudgetItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetItem = await _context.Budgets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (budgetItem == null)
            {
                return NotFound();
            }

            return View(budgetItem);
        }

        // POST: BudgetItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var budgetItem = await _context.Budgets.FindAsync(id);
            if (budgetItem != null)
            {
                _context.Budgets.Remove(budgetItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BudgetItemExists(int id)
        {
            return _context.Budgets.Any(e => e.Id == id);
        }
    }
}
