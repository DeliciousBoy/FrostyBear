using FrostyBear.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FrostyBear.Controllers
{
    public class ShopLoginController : Controller
    {
        private readonly FrostyBearContext _db;

        public ShopLoginController(FrostyBearContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Customer model)
        {
            var user = await _db.Customers.FirstOrDefaultAsync(u => u.CustomerUsername == model.CustomerUsername && u.CustomerPassword == model.CustomerPassword);

            if (user != null)
            {
                TempData["SuccessMessage"] = "Login successful!";
                return RedirectToAction("Index", "About"); // Redirect to the dashboard
            }
            else
            {
                TempData["ErrorMessage"] = "Incorrect username or password.";
                return RedirectToAction("Index"); // Redirect back to the login page
            }
        }
    }
}
