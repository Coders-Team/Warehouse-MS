using Microsoft.AspNetCore.Mvc;

namespace Warehouse_MS.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
