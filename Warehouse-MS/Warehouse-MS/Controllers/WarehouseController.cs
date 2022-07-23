using Microsoft.AspNetCore.Mvc;

namespace Warehouse_MS.Controllers
{
    public class WarehouseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
