using Microsoft.AspNetCore.Mvc;

namespace Warehouse_MS.Controllers
{
    public class ProductTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
