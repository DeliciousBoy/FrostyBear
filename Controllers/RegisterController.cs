using FrostyBear.Models;
using Microsoft.AspNetCore.Mvc;
using FrostyBear.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Customer Cusobj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   //_db.Products.Add(Cusobj);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(Cusobj);
            }
            ViewBag.ErrorMessage = "การบันทึกผิดพลาด";
            return View(Cusobj);

        }
    }
    }