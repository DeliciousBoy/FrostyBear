using Microsoft.AspNetCore.Mvc;

namespace FrostyBear.Controllers
{
    public class RaweeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
