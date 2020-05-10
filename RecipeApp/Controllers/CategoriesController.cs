using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Models;

namespace RecipeApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly RecipeDbContextController _context;

        public CategoriesController(RecipeDbContextController context)
        {
            _context = context;
        }

        // GET: Categories
        public IActionResult Index()
        {
<<<<<<< HEAD
            return View(await _context.Categorie.ToListAsync());
=======
            List<Category> _categories = _categoryService.GetAll();
            return View(_categories);
>>>>>>> feature/add-authentication-basics
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
<<<<<<< HEAD
            if (id == null)
            {
                return NotFound();
            }
=======
            var category = _categoryService.Details(id);
>>>>>>> feature/add-authentication-basics

            var category = await _context.Categorie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
<<<<<<< HEAD
                _context.Add(category);
                await _context.SaveChangesAsync();
=======
                isCreated =  _categoryService.Add(category);
            }
            
            if (isCreated)
            {
>>>>>>> feature/add-authentication-basics
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public IActionResult Edit(int? id)
        {
<<<<<<< HEAD
            if (id == null)
            {
                return NotFound();
            }
=======
            var category = _categoryService.GetEdit(id);
>>>>>>> feature/add-authentication-basics

            var category = await _context.Categorie.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
<<<<<<< HEAD
                try
=======
                bool isEdited = _categoryService.Edit(category);
                if (isEdited)
>>>>>>> feature/add-authentication-basics
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

        // GET: Categories/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
            var category = await _context.Categorie
                .FirstOrDefaultAsync(m => m.Id == id);
=======
            var category = _categoryService.GetDelete(id);

>>>>>>> feature/add-authentication-basics
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
<<<<<<< HEAD
            var category = await _context.Categorie.FindAsync(id);
            _context.Categorie.Remove(category);
            await _context.SaveChangesAsync();
=======
            _categoryService.Delete(id);
>>>>>>> feature/add-authentication-basics
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categorie.Any(e => e.Id == id);
        }
    }
}
