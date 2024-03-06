using FrostyBear.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FrostyBear.Controllers
{
    public class RegisterController : Controller
    {
        private readonly FrostyBearContext _db;

        public RegisterController(FrostyBearContext db)
        {
            _db = db;
        }

        // GET: /Register
        public IActionResult Index()
        {
            return View(new Customer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Add this line for security
        public async Task<IActionResult> Register(Customer model)
        {
            if (ModelState.IsValid)
            {
                // Check if the username is already taken
                var existingUser = await _db.Customers.FirstOrDefaultAsync(u => u.CustomerUsername == model.CustomerUsername);

                if (existingUser != null)
                {
                    TempData["ErrorMessage"] = "Username already exists.";
                    return RedirectToAction("Index");
                }

                // Add the new user to the database
                _db.Customers.Add(model);
                await _db.SaveChangesAsync();

                TempData["SuccessMessage"] = "Account created successfully.";
                return RedirectToAction("Index");
            }

            // If model state is not valid, return to the registration page with validation errors
            return View("Index", model);
        }
    }
    }