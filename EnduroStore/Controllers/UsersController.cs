using EnduroStore.Data;
using EnduroStore.Data.Models;
using EnduroStore.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly EnduroStoreDbContext db;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(SignInManager<User> signInManager, UserManager<User> userManager, EnduroStoreDbContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.db = db;
        }

        public IActionResult Login() => View();
        public IActionResult Register() => View();

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();


            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel user)
        {
            var userIsExists = this.db.Users.Where(x => x.FullName == user.FullName).FirstOrDefault();

            if(userIsExists != null)
            {
                ModelState.AddModelError(string.Empty, $"User {user.FullName} already exists!");
            }

           if(user.Password != user.ConfirmPassword)
           {
               ModelState.AddModelError(string.Empty, "Password and confirm password don't match");
           }

            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var registeredUser = new User
            {
                Email = user.Email,
                UserName = user.FullName,
                FullName = user.FullName
            };

          var result = await this.userManager.CreateAsync(registeredUser, user.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(s => s.Description);

                foreach (var item in errors)
                {
                    ModelState.AddModelError(string.Empty, item);
                }

                return View(user);
            }

            this.db.SaveChanges();

            return RedirectToAction("Login", "Users");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel user)
        {
            var loggedUser = await this.userManager.FindByNameAsync(user.Username);

            if(loggedUser == null)
            {
                ModelState.AddModelError(string.Empty, "Credentials invalid!");

                return View(user);
            }

            var passwordIsValid = await this.userManager.CheckPasswordAsync(loggedUser, user.Password);

            if (!passwordIsValid)
            {
                ModelState.AddModelError(string.Empty, "Credentials invalid!");

                return View(user);
            }

            await this.signInManager.SignInAsync(loggedUser, true);

            return RedirectToAction("Index", "Home");
        }
    }
}
