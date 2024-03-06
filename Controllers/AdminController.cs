using FrostyBear.Models;
using Microsoft.AspNetCore.Mvc;


namespace FrostyBear.Controllers
{
    public class AdminController : Controller
    {
        private readonly FrostyBearContext _db;
        public AdminController(FrostyBearContext db) { _db = db; }


        public ActionResult Index() 
        { 
            if(HttpContext.Session.GetString("EmployeeUsername") == null) 
            {  
                return RedirectToAction("AdminLogin"); 
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdminLogin(String username, string password)
        {
            var users = from user in _db.Employees
                        where user.EmployeeUsername.Equals(username)
                            && user.EmployeePassword.Equals(password)
                        select user;
            
            if(users.Count() == 0) 
            {
                TempData["ErrorMessage"] = "Invalid Username or Password";
                return View();
            }

            string EmployeeUsername;
            
            foreach (var item in users)
            {
                
                EmployeeUsername = item.EmployeeUsername;
                HttpContext.Session.SetString("EmployeeUsername", EmployeeUsername);

            }
            return RedirectToAction("Index");
        }
        
    }
}


/* var user = await _db.Employees.FirstOrDefaultAsync(u => u.EmployeeUsername == model.EmployeeUsername && u.EmployeePassword == model.EmployeePassword);

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
*/