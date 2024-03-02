using FrostyBear.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;


namespace FrostyBear.Controllers
{
    public class AdminLoginController : Controller
    {
        private readonly FrostyBearContext _db;
        public AdminLoginController(FrostyBearContext db)
        { _db = db; }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Employee model)
        {
            var user = await _db.Employees.FirstOrDefaultAsync(u => u.EmployeeUsername == model.EmployeeUsername && u.EmployeePassword == model.EmployeePassword);

            if (user != null)
            {
                TempData["SuccessMessage"] = "เข้าสู่ระบบสำเร็จ!";
                return RedirectToAction("Index", "Dashboard"); // นำไปยังหน้า Dashboard
                
            }
            else
            {
                TempData["ErrorMessage"] = "ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง";
                return View(model);
            }
        }
      
    }
}


