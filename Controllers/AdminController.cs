using FrostyBear.Models;
using Microsoft.AspNetCore.Mvc;


namespace FrostyBear.Controllers
{
    public class AdminController : Controller
    {
        
        public readonly FrostyBearContext _db;
        public AdminController(FrostyBearContext db) { _db = db; }
        public IActionResult Index() 
        { 
            
            if(HttpContext.Session.GetString("EmployeeUsername") == null) 
            {  
                return RedirectToAction("AdminLogin"); 
            }
            
            return View();
        }
        public IActionResult AdminLogin()
        {
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

        public IActionResult AdminLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        
       


    }
}
