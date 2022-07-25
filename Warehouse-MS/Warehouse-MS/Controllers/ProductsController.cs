using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Warehouse_MS.Models;
using Warehouse_MS.Models.DTO;
using Warehouse_MS.Models.Interfaces;

namespace Warehouse_MS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProduct _product;

        public ProductsController(IProduct product)
        {
            _product = product;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _product.GetProducts();

            return View(products);
        }


        // GET: Products/Details?id=5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _product.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductDto product)
        {
            if (ModelState.IsValid)
            {

                await _product.Create(product);

                return RedirectToAction("Index");


            }
            else
            {
                return View(product);
            }
        }


        // GET: Products/Edit?id=2
        public async Task<IActionResult> Edit(int id)
        {

            var Getproduct = await _product.GetProduct(id);


            if (Getproduct == null)
            {
                return NotFound();
            }

            return View(Getproduct);
        }

        // POST: Products/Edit?id=5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (ModelState.IsValid)
            {

                await _product.UpdateProduct(id, product);

                return RedirectToAction("Index");

            }
            else
            {

                return View(product);
            }
        }

        //Delete: products/DeleteProduct?id=1
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _product.DeleteProduct(id);


            return RedirectToAction("Index");
        }


        // GET: Products/GetByBarCode?barcode=
        public async Task<IActionResult> GetByBarCode(string barcode)
        {
            var product = await _product.GetByBarCode(barcode);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
