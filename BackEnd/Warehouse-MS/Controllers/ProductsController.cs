using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse_MS.Data;
using Warehouse_MS.Models;
using Warehouse_MS.Models.DTO;
using Warehouse_MS.Models.Interfaces;

namespace Warehouse_MS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _product;
        //test
        public ProductsController(IProduct product)
        {
            _product = product;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _product.GetProducts();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            Product product = await _product.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            var modifiedProduct = await _product.UpdateProduct(id, product);

            return Ok(modifiedProduct);
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(ProductDto product)
        {
            ProductDto newProduct = await _product.Create(product);
            return Ok(newProduct);

        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {

            Product product = await _product.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            await _product.DeleteProduct(id);
            return NoContent();

        }


        // GET: api/Products/SortByDate/false
        [HttpGet("SortByDate/{flag}")]
        public async Task<ActionResult<IEnumerable<Product>>> SortByDate(bool flag)
        {
            var products = await _product.SortByDate(flag);
            return Ok(products);
        }

        // GET: api/Products/SortByExpirationDate/true
        [HttpGet("SortByExpirationDate/{flag}")]
        public async Task<ActionResult<IEnumerable<Product>>> SortByExpirationDate(bool flag)
        {
            var products = await _product.SortByExpirationDate(flag);
            return Ok(products);
        }

        // GET: api/Products/SortByWeight/true
        [HttpGet("SortByWeight/{flag}")]
        public async Task<ActionResult<IEnumerable<Product>>> SortByWeight(bool flag)
        {
            var products = await _product.SortByWeight(flag);
            return Ok(products);
        }

        // GET: api/Products/SortBySize/true
        [HttpGet("SortBySize/{flag}")]
        public async Task<ActionResult<IEnumerable<Product>>> SortBySize(bool flag)
        {
            var products = await _product.SortBySize(flag);
            return Ok(products);
        }


        // GET: api/Products/FilterByProductType/food
        [HttpGet("FilterByProductType/{input}")]
        public async Task<ActionResult<IEnumerable<Product>>> FilterByProductType(string input)
        {
            var products = await _product.FilterByProductType(input);
            return Ok(products);
        }


        // GET: api/Products/FilterByStorageType/on shelves
        [HttpGet("FilterByStorageType/{input}")]
        public async Task<ActionResult<IEnumerable<Product>>> FilterByStorageType(string input)
        {
            var products = await _product.FilterByStorageType(input);
            return Ok(products);
        }

        // GET: api/Products/GenerateBarCode/
        [HttpGet("GenerateBarCode")]
        public async Task<ActionResult<string>> GenerateBarCode()
        {
            var BarCode = await _product.GenerateBarCode();
            return Ok(BarCode);
        }

        // GET: api/Products/GetByBarCode/BAR676197
        [HttpGet("GetByBarCode/{barcode}")]
        public async Task<ActionResult<Product>> GetByBarCode(string barcode)
        {
            var product = await _product.GetByBarCode(barcode);
            if (product == null)
            {
                return NotFound("Product NOt found");
            }
            return Ok(product);
        }


        // GET: api/Products/Packing/1/20/1
        [HttpGet("Packing/{id}/{newWeight}/{newSize}")]
        public async Task<ActionResult<IEnumerable<Product>>> Packing(int id, int newWeight, int newSize)
        {

            var products = await _product.Packing(id, newWeight, newSize);

            if (products == null)
            {
                return BadRequest("can NOT divided");
            }

            return Ok(products);
        }


    }
}
