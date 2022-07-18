using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse_MS.Data;
using Warehouse_MS.Models.Interfaces;

namespace Warehouse_MS.Models.Services
{
    public class ProductServices : IProduct
    {
        private readonly WarehouseDBContext _context;

       public ProductServices(WarehouseDBContext context)
       {
            _context = context;
       }

    public async Task<Product> Create(Product product)
    {
            _context.Entry(product).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return product;

    }

        public async Task DeleteProduct(int Id)
        {
            Product product = await GetProduct(Id);

            _context.Entry(product).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }

        public async Task<Product> GetProduct(int Id)
        {
            Product product = await _context.Product.FindAsync(Id);
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await _context.Product.ToListAsync();
            return products;
        }

        public async Task<Product> UpdateProduct(int Id, Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;


        }
    }
}
