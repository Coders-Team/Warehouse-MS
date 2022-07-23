using Microsoft.AspNetCore.Mvc;

namespace Warehouse_MS.Controllers
{
    public class StorageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
