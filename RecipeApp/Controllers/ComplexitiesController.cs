using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Models;

namespace RecipeApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ComplexitiesController : Controller
    {
        private readonly IComplexityService _complexityService;

        public ComplexitiesController(IComplexityService complexityService)
        {
            _complexityService = complexityService;
        }

        // GET: Complexities
        public async Task<IActionResult> Index()
        {
            List<Complexity> _complexities = _complexityService.GetAll();
            return View(_complexities);
        }

        // GET: Complexities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var complexity = _complexityService.Details(id);

            if (complexity == null)
            {
                return NotFound();
            }

            return View(complexity);
        }

        // GET: Complexities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Complexities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Complexity complexity)
        {
            bool isCreated = false;

            if (ModelState.IsValid)
            {
                isCreated = _complexityService.Add(complexity);
            }

            if (isCreated)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(complexity);
        }

        // GET: Complexities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var complexity = _complexityService.GetEdit(id);

            if (complexity == null)
            {
                return NotFound();
            }

            return View(complexity);
        }

        // POST: Complexities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Complexity complexity)
        {
            if (id != complexity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bool isEdited = _complexityService.Edit(complexity);
                if (isEdited)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(complexity);
        }

        // GET: Complexities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complexity = _complexityService.GetDelete(id);

            if (complexity == null)
            {
                return NotFound();
            }

            return View(complexity);
        }

        // POST: Complexities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _complexityService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
