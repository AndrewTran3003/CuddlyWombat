using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using CuddlyWombat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CuddlyWombat.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RegistrationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            CreateRoles();
        }
        // GET: /<controller>/
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(SystemUserRegistration systemUserRegistration)
        {
            if (!ModelState.IsValid)
            {
                return View(systemUserRegistration);
            }
   
            var user = new IdentityUser
            {
                UserName = systemUserRegistration.UserName, 
            };
            string roleValue = systemUserRegistration.UserRole;

            var result = await _userManager.CreateAsync(user, systemUserRegistration.Password);
            if (!result.Succeeded)
            {

                foreach (var error in result.Errors.Select(x => x.Description))
                {
                    ModelState.AddModelError("", error);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(user, roleValue);
            return Redirect("../Home");

        }

       private void CreateRoles()
        {
            var Admin = new IdentityRole();
            Admin.Name = "Admin";
            var FOH = new IdentityRole();
            FOH.Name = "FOH";
            var BOH = new IdentityRole();
            FOH.Name = "BOH";
            var AR = new IdentityRole();
            FOH.Name = "AR";
            var Acc = new IdentityRole();
            FOH.Name = "Acc";
            _roleManager.CreateAsync(Admin);
            _roleManager.CreateAsync(FOH);
            _roleManager.CreateAsync(BOH);
            _roleManager.CreateAsync(AR);
            _roleManager.CreateAsync(Acc);
        }
    }
}
