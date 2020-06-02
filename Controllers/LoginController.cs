using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuddlyWombat.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CuddlyWombat.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public LoginController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SystemUserLogin login)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(
                login.UserName, login.Password, true, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Try Again!");
                return View();
            }
            return Redirect("../Home");
        }
    }
}