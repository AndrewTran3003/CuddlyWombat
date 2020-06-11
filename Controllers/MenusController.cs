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
            return View(await _context.Menus.Include(i => i.ItemMenus).ThenInclude(i => i.Item).ToListAsync());
        }

   
    }
}
