using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse_MS.Models;
using Warehouse_MS.Models.Interfaces;

namespace Warehouse_MS.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly IProductType _productType;

        public ProductTypeController(IProductType productType)
        {
            this._productType = productType;
        }

        // GET: api/ProductTypes
        [HttpGet]
        public async Task<ActionResult> Index()
        {
             IEnumerable < ProductType > productType = await _productType.GetProductTypes();
            return View(productType);
        }

        // GET: api/ProductType/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Details(int id)
        {
            ProductType productType = await _productType.GetProductType(id);
            if (productType == null)
            {
                return View("Error");
            }
            return View(productType);
        }

        // PUT: api/ProductType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, ProductType productType)
        {
            if (id != productType.Id)
            {
                return View("Error");
            }
            ProductType newProductType = await _productType.UpdateProductType(id, productType);

            return View(newProductType);
        }

        // POST: api/ProductType
        [HttpPost]
        public async Task<ActionResult<ProductType>> Add(ProductType productType)
        {
            ProductType newProductType = await _productType.Create(productType);
            return View(newProductType);

        }

        // DELETE: api/ProductType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ProductType productType = await _productType.GetProductType(id);
            if (productType == null)
            {
                return View("Error");
            }
            await _productType.Delete(id);
            return Redirect("/");

        }

    }
}
