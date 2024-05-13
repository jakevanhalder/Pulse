using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PulseWeb.Data;
using PulseWeb.Models;
using PulseWeb.Repository.IRepository;

namespace PulseWeb.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoController(IToDoRepository todoRepository)
        {
            _toDoRepository = todoRepository;
        }

        // GET: ToDo
        public IActionResult Index()
        {
            List<ToDoItem> objToDoList = _toDoRepository.GetAll().ToList();
            return View(objToDoList);
        }

        // GET: ToDoItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Description,IsDone,DueDate")] ToDoItem toDoItem)
        {
            if (ModelState.IsValid)
            {
                _toDoRepository.Add(toDoItem);
                _toDoRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(toDoItem);
        }

        // GET: ToDoItems/Edit/id
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var toDoItem = _toDoRepository.Get(u => u.Id == id);
            if (toDoItem == null)
            {
                return NotFound();
            }
            return View(toDoItem);
        }

        // POST: ToDoItems/Edit/id
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Description,IsDone,DueDate")] ToDoItem toDoItem)
        {
            if (id != toDoItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _toDoRepository.Update(toDoItem);
                _toDoRepository.Save();
                TempData["success"] = "ToDo updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(toDoItem);
        }

        // GET: ToDoItems/Delete/id
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoItem = _toDoRepository.Get(u => u.Id == id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return View(toDoItem);
        }

        // POST: ToDoItems/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var toDoItem = _toDoRepository.Get(u => u.Id == id);
            if (toDoItem != null)
            {
                _toDoRepository.Remove(toDoItem);
            }

            _toDoRepository.Save();
            TempData["success"] = "ToDo deleted";
            return RedirectToAction(nameof(Index));
        }
    }
}
