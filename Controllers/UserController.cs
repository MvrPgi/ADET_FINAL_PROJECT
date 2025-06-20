using ADET_FINAL_PROJECT.Data;
using ADET_FINAL_PROJECT.Models;
using ADET_FINAL_PROJECT.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ADET_FINAL_PROJECT.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = dbContext.Users
                .FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user != null)
            {
                HttpContext.Session.SetString("Username", user.Username);
                return RedirectToAction("Inventory", "Item");
            }

            ViewBag.Message = "Invalid login";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ViewBag.Message = "Passwords do not match";
                return View();
            }

            var existingUser = dbContext.Users.FirstOrDefault(u => u.Username == model.Username);
            if (existingUser != null)
            {
                ViewBag.Message = "Username already exists";
                return View();
            }

            var newUser = new User
            {
                ID = Guid.NewGuid(),
                Username = model.Username,
                Password = model.Password 
            };

            dbContext.Users.Add(newUser);
            await dbContext.SaveChangesAsync();

            HttpContext.Session.SetString("Username", newUser.Username);

            return RedirectToAction("Inventory", "Item");
        }
    }
}

