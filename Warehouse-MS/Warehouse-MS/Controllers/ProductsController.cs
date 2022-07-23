using Microsoft.AspNetCore.Mvc;

namespace Warehouse_MS.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
