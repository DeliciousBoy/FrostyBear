using Microsoft.AspNetCore.Mvc;

namespace FrostyBear.Controllers
{
    public class IT : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
