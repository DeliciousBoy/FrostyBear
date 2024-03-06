using FrostyBear.Models;
using FrostyBear.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;


namespace FrostyBear.Controllers
{
    public class HomeController : Controller
    {
        private readonly FrostyBearContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(FrostyBearContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Shop");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Shop()
        {
            var pdvm = from p in _db.Products.Take(4)
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
    }
}
