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
    public class ContactMessagesController : Controller
    {
        private readonly IContactMessageService _contactMessageService;

        public ContactMessagesController(IContactMessageService contactMessageService)
        {
            _contactMessageService = contactMessageService;
        }

        // GET: ContactMessages
        public IActionResult Index()
        {
            List<ContactMessage> contactMessages = _contactMessageService.GetAll();
            return View(contactMessages);
        }

        // GET: ContactMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var contactMessage = _contactMessageService.Details(id);

            if(!contactMessage.Read)
            {
                contactMessage.Read = true;
                _contactMessageService.Edit(contactMessage);
            }

            if (contactMessage == null)
            {
                return NotFound();
            }

            return View(contactMessage);
        }

        // GET: ContactMessages/Create
        public IActionResult Create()
        {
            return RedirectToAction(nameof(Index));
            //return View();
        }

        // POST: ContactMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FullName,Email,Messsage")] ContactMessage contactMessage)
        {
            return RedirectToAction(nameof(Index));
            //if (ModelState.IsValid)
            //{
            //    _context.Add(contactMessage);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(contactMessage);
        }

        // GET: ContactMessages/Edit/5
        public IActionResult Edit(int? id)
        {
            return RedirectToAction(nameof(Index));
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var contactMessage = await _context.ContactMessages.FindAsync(id);
            //if (contactMessage == null)
            //{
            //    return NotFound();
            //}
            //return View(contactMessage);
        }

        // POST: ContactMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,FullName,Email,Messsage")] ContactMessage contactMessage)
        {
            return RedirectToAction(nameof(Index));
            //if (id != contactMessage.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(contactMessage);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!ContactMessageExists(contactMessage.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(contactMessage);
        }

        // GET: ContactMessages/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactMessage = _contactMessageService.GetDelete(id);

            if (contactMessage == null)
            {
                return NotFound();
            }

            if (!contactMessage.Read)
            {
                contactMessage.Read = true;
                _contactMessageService.Edit(contactMessage);
            }

            return View(contactMessage);
        }

        // POST: ContactMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _contactMessageService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
