using FrostyBear.Models;
using Microsoft.AspNetCore.Mvc;
using FrostyBear.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace FrostyBear.Controllers
{
    public class ProductController : Controller
    {
        public readonly FrostyBearContext _db;

        public ProductController(FrostyBearContext db)
        { _db = db; }

        public IActionResult Index()
        {
            var pdvm = from p in _db.Products
                       join pt in _db.Categories on p.CategoryId equals pt.CategoryId into join_p_pt
                       from p_pt in join_p_pt.DefaultIfEmpty()
                       join b in _db.Brands on p.BrandId equals b.BrandId into join_p_b
                       from p_b in join_p_b.DefaultIfEmpty()

                       select new PdVM
                       {
                           ProductId = p.ProductId,
                           ProductName = p.ProductName,
                           CategoryName = p_pt.CategoryName,
                           BrandName = p_b.BrandName,
                           ProductPrice = p.ProductPrice,
                           ProductCost = p.ProductCost,
                           ProductStock = p.ProductStock,
                           Detail = p.Detail
                       };

            if (pdvm == null) return NotFound();
            return View(pdvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string? stext)
        {
            if (stext == null)
            {
                return RedirectToAction("Index");
            }
            {
                var pdvm = from p in _db.Products
                           join pt in _db.Categories on p.CategoryId equals pt.CategoryId into join_p_pt
                           from p_pt in join_p_pt.DefaultIfEmpty()
                           join b in _db.Brands on p.BrandId equals b.BrandId into join_p_b
                           from p_b in join_p_b.DefaultIfEmpty()

                           where p.ProductName.Contains(stext)||
                           p_b.BrandName.Contains(stext)||
                           p_pt.CategoryName.Contains(stext)

                           select new PdVM
                           {
                               ProductId = p.ProductId,
                               ProductName = p.ProductName,
                               CategoryName = p_pt.CategoryName,
                               BrandName = p_b.BrandName,
                               ProductPrice = p.ProductPrice,
                               ProductCost = p.ProductCost,
                               ProductStock = p.ProductStock,
                               Detail = p.Detail
                           };
                if (pdvm == null) return NotFound();
                ViewBag.stext = stext;
                return View(pdvm);
            }
        }

        public IActionResult Crate()
        {
            ViewData["Categories"] = new SelectList(_db.Categories, "CategoryId", "CategoryName");
            ViewData["Brand"] = new SelectList(_db.Brands, "BrandId", "BrandName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Products.Add(obj);  
                    _db.SaveChanges(); 
                    return RedirectToAction("Index"); 
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(obj);
            }
            ViewBag.ErrorMessage = "การบันทึกผิดพลาด";
            return View(obj);
        }

        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                ViewBag.ErrorMessage = "ระบุ id";
                return RedirectToAction("Index");
            }
            var obj = _db.Products.Find(id);
            if (obj == null)
            {
                ViewBag.ErrorMessage = "ไม่พบข้อมูล";
                return RedirectToAction("Index");
            }
            ViewData["Categories"] = new SelectList(_db.Categories, "CategoryId", "CategoryName",obj.ProductId);
            ViewData["Brand"] = new SelectList(_db.Brands, "BrandId", "BrandName",obj.BrandId);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Products.Update(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(obj);
            }
            ViewBag.ErrorMessage = "การแก้ไขผิดพลาด";
            ViewData["Categories"] = new SelectList(_db.Categories, "CategoryId", "CategoryName", obj.ProductId);
            ViewData["Brand"] = new SelectList(_db.Brands, "BrandId", "BrandName", obj.BrandId);
            return View(obj);
        }

        public IActionResult Delete(String id)
        {
            if (id == null)
            {
                ViewBag.ErrorMessage = "ระบุ id";
                return RedirectToAction("Index");
            }
            var obj = _db.Products.Find(id);
            if (obj == null)
            {
                ViewBag.ErrorMessage = "ไม่พบข้อมูล";
                return RedirectToAction("Index");
            }
            ViewBag.pdtName = _db.Categories.FirstOrDefault(pt => pt.CategoryId == obj.CategoryId);
            ViewBag.brandName = _db.Brands.FirstOrDefault(br => br.BrandId == obj.BrandId);
            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(string Pdid)
        {
            try
            {
                var obj = _db.Products.Find(Pdid);
                if (obj == null)
                {
                    ViewBag.ErrorMessage = "ไม่พบข้อมูล";
                    return RedirectToAction("Index");
                }
                _db.Products.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}