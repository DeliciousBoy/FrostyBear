using FrostyBear.Models;
using FrostyBear.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
			//return View();
			return RedirectToAction("Shop");

		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Shop(string? stext)
		{
			if (stext == null)
			{
				return RedirectToAction("Index");
			}
			var pdvm = from p in _db.Products
					   join pt in _db.Categories on p.CategoryId equals pt.CategoryId into join_p_pt
					   from p_pt in join_p_pt.DefaultIfEmpty()
					   where p.ProductName.Contains(stext) ||
							 p_pt.CategoryName.Contains(stext)
					   select new PdVM
					   {
						   ProductId = p.ProductId,
						   ProductName = p.ProductName,
						   CategoryName = p_pt.CategoryName,
						   ProductPrice = p.ProductPrice,
						   ProductCost = p.ProductCost,
						   ProductStock = p.ProductStock,
						   Detail = p.Detail
					   };
			if (pdvm == null) return NotFound();
			ViewBag.stext = stext;
			return View(pdvm);
		}
		public IActionResult Shop()
		{
			var pdvm = from p in _db.Products
					   join pt in _db.Categories on p.CategoryId equals pt.CategoryId into join_p_pt
					   from p_pt in join_p_pt.DefaultIfEmpty()
					   select new PdVM
					   {
						   ProductId = p.ProductId,
						   ProductName = p.ProductName,
						   CategoryName = p_pt.CategoryName,
						   ProductPrice = p.ProductPrice,
						   ProductCost = p.ProductCost,
						   ProductStock = p.ProductStock,
						   Detail = p.Detail
					   };
			var FilterCategory = from t in _db.Categories
								 select new
								 {
									 PdtId = t.CategoryId,
									 PdtName = t.CategoryName,
								 };
			if (pdvm == null) return NotFound();
			ViewBag.ErrorMessage = TempData["ErrorMessage"];
			ViewData["FilterCategory"] = FilterCategory.ToList();
			return View(pdvm);
		}

		public IActionResult Login()
		{
			return View();
		}
	}
}