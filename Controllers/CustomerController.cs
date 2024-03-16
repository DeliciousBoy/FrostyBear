using FrostyBear.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FrostyBear.Controllers
{
    public class CustomerController : Controller
    {
        private readonly FrostyBearContext _db;
        public CustomerController(FrostyBearContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Show(string id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "ต้องระบุ ID";
                return RedirectToAction("Index");
            }
            var obj = _db.Customers.Find(id);
            if (obj == null)
            {
                TempData["ErrorMessage"] = "หา ID ไม่พบ";
                return RedirectToAction("Index");
            }
            var fileName = id.ToString() + ".jpg";
            var imgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\imagcus");
            var filePath = Path.Combine(imgPath, fileName);

            if (System.IO.File.Exists(filePath))
            {
                ViewBag.ImgFile = "/imagcus/" + id + ".jpg";
            }
            else
            {
                ViewBag.ImgFile = "/imagcus/login.jpg";
            }
            return View(obj);
        }
        public IActionResult ImgUpload(IFormFile imgfiles, string theid)
        {
            var FileName = theid;
            //var FileExtension = Path.GetExtension(imgfiles.FileName);
            var FileExtension = ".jpg";
            var SaveFileName = FileName + FileExtension;
            var SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\imagcus");
            var SaveFilePath = Path.Combine(SavePath, SaveFileName);
            using (FileStream fs = System.IO.File.Create(SaveFilePath))
            {
                imgfiles.CopyTo(fs);
                fs.Flush();
            }

            return RedirectToAction("Show", new { id = theid });
        }

        public IActionResult ImgDelete(string id)
        {
            var fileName = id.ToString() + ".jpg";
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\imagcus");
            var filePath = Path.Combine(imagePath, fileName);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            return RedirectToAction("Show", new { id = id });
        }
    }
}
