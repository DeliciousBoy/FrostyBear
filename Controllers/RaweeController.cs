using Microsoft.AspNetCore.Mvc;

namespace FrostyBear.Controllers
{
    public class RaweeController : Controller
    {
        public IActionResult Index()
        {
            1 = 2;
            return View();
        }
    }
}
