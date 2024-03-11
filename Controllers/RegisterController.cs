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
        public IActionResult Register(Customer Cusobj,string CustomerUsername)
        {
            var cus = from c in _db.Customers
                      where c.CustomerUsername.Equals(CustomerUsername)
                      select c;
            try
            {
                if (ModelState.IsValid)
                {
                    if (cus.ToList().Count() == 0)
                    {
                        Cusobj.Startdate = DateOnly.FromDateTime(DateTime.Now);
                        _db.Customers.Add(Cusobj);
                        _db.SaveChanges();
                        return RedirectToAction("Index", "ShopLogin");
                    }
                    else {
                        TempData["ErrorMessage"] = "มีคนใช่ชื่อนี้แล้ว";
                        return RedirectToAction("Index");
                    }
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