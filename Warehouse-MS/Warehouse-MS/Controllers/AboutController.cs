using Microsoft.AspNetCore.Mvc;

namespace Warehouse_MS.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
