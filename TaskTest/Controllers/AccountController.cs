using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TaskTest.Constants;
using TaskTest.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskTest.Controllers
{

    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Register()
        {
            if (signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO data)
        {
            if (signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                string inputDate = data.BirthDay.ToString();
                DateOnly birthDay = DateOnly.ParseExact(inputDate, "MM/dd/yyyy");

                User user = new()
                {
                    Name = data.Name,
                    Surname = data.Surname,
                    UserName = data.Email,
                    Email = data.Email,
                    Phone = data.Phone,
                    Gender = data.Gender,
                    CreatedAt = data.CreatedAt,
                    UpdatedAt = data.UpdatedAt,
                    IsDeleted = data.IsDeleted,
                    EmailConfirmed = true,
                    BirthDay = birthDay,
                };
                var password = data.Password;
                var result = await userManager.CreateAsync(user, data.Password);
                await userManager.AddToRoleAsync(user, Roles.User.ToString());

                //DbContext.SaveChanges();

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                    //return View("Index");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                //return View(data);
            }
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO data)
        {
            if (signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(data.Email,
                           data.Password, data.RememberMe, lockoutOnFailure: true);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

    }
}
