using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CuddlyWombat.Data;
using CuddlyWombat.Models;
using Microsoft.AspNetCore.Authorization;

namespace CuddlyWombat.Controllers
{
    [Authorize]
    public class MenusController : Controller
    {
        private readonly CuddlyWombatContext _context;

        public MenusController(CuddlyWombatContext context)
        {
            _context = context;
        }

        // GET: Menus
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            //var viewModel = new InstructorIndexData();
            return View(await _context.Menus.ToListAsync());
        }

        // GET: Menus/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var menu = await _context.Menus
                .FirstOrDefaultAsync(m => m.ID == id);*/
            var menu = await _context.Menus
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }

        // GET: Menus/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Type,Price,Name,Description,DateCreated")] Menu menu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    menu.ID = Guid.NewGuid();
                    _context.Add(menu);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes");
            }
            return View(menu);
        }

        // GET: Menus/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id, [Bind("Type,Price,ID,Name,Description,DateCreated")] Menu menu)
        {
            if (id != menu.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.ID))
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
            return View(menu);
        }

        // GET: Menus/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _context.Menus
                .FirstOrDefaultAsync(m => m.ID == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var menu = await _context.Menus.FindAsync(id);
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(Guid id)
        {
            return _context.Menus.Any(e => e.ID == id);
        }
    }
}
