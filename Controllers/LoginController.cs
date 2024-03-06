using FrostyBear.Models;
using FrostyBear.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FrostyBear.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Employee model)
        {
            if (ModelState.IsValid)
            {
                // เช็ค Username และ Password จากฐานข้อมูล หรือตรวจสอบเงื่อนไขอื่น ๆ ตามต้องการ
                bool isValid = CheckCredentials(model.EmployeeUsername, model.EmployeePassword);

                if (isValid)
                {
                    // หากการล็อกอินสำเร็จ ทำการ Redirect ไปยังหน้าหลักหรือหน้าที่ต้องการ
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // หากรหัสผิด ให้เพิ่มข้อความแจ้งเตือนใน ModelState
                    ModelState.AddModelError(string.Empty, "ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง");
                    // แจ้งเตือนว่ารหัสผ่านผิด
                }
            }
            else
            {
                // หากมีข้อผิดพลาดในการกรอกข้อมูล กลับไปแสดงหน้า Login พร้อมกับแสดงข้อผิดพลาด
                ModelState.AddModelError(string.Empty, "กรุณากรอกชื่อผู้ใช้และรหัสผ่าน");
            }

            // กลับไปที่หน้า Login หลังจากตรวจสอบและเพิ่มข้อความแจ้งเตือนแล้ว
            return View(model);
        }

        // เมธอดสำหรับตรวจสอบ Username และ Password ในฐานข้อมูล
        private bool CheckCredentials(string EmployeeUsername, string EmployeePassword)
        {
            // ตรวจสอบและคืนค่าตามผลลัพธ์จากการตรวจสอบ
            return true; // หรือ false ตามที่ต้องการ
        }
    }
}
