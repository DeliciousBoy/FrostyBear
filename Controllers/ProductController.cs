using FrostyBear.Models;
using Microsoft.AspNetCore.Mvc;
using FrostyBear.ViewModels;
namespace FrostyBear.Controllers
{
    public class ProductController : Controller
    {
        public readonly FrostyBearContext _db;

        public ProductController(FrostyBearContext db)
        { _db = db; }

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
                               Detail = p.Detail
                           };
                if (pdvm == null) return NotFound();
                ViewBag.stext = stext;
                return View(pdvm);
            }
        }
    }
}