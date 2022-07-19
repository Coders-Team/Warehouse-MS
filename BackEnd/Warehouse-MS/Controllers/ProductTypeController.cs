using Warehouse_MS.Models;
using Warehouse_MS.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse_MS.Models;

namespace Warehouse_MS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : Controller
    {
        private readonly IProductType _productType;

        public ProductTypeController(IProductType productType)
        {
            this._productType = productType;
        }

        // GET: api/ProductTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductType>>> GeProductTypes()
        {
            var productType = await _productType.GetProductTypes();
            return Ok(productType);
        }

        // GET: api/ProductType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> GetProductType(int id)
        {
            ProductType productType = await _productType.GetProductType(id);
            if (productType == null)
            {
                return NotFound();
            }
            return Ok(productType);
        }

        // PUT: api/ProductType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductType(int id, ProductType productType)
        {
            if (id != productType.Id)
            {
                return BadRequest();
            }
            ProductType newProductType = await _productType.UpdateProductType(id, productType);

            return Ok(newProductType);
        }

        // POST: api/ProductType
        [HttpPost]
        public async Task<ActionResult<ProductType>> PostProductType(ProductType productType)
        {
            ProductType newProductType = await _productType.Create(productType);
            return Ok(newProductType);

        }

        // DELETE: api/ProductType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductType(int id)
        {
            ProductType productType = await _productType.GetProductType(id);
            if (productType == null)
            {
                return NotFound();
            }
            await _productType.Delete(id);
            return NoContent();

        }


    }
}
