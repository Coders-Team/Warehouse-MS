using Warehouse_MS.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse_MS.Data;
using Warehouse_MS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Warehouse_MS.Models.Services
{
    public class ProductTypeService : IProductType
    {

        private readonly WarehouseDBContext _context;
        

        public ProductTypeService(WarehouseDBContext context )
        {
            _context = context;
        }
        
       
        // method to create new productType

        public async Task<ProductType> Create(ProductType productType)
        {
            _context.Entry(productType).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return productType;
        }

        // method to Delete a Category

        public async Task Delete(int id)
        {


            ProductType productType = await _context.ProductType.FindAsync(id);

            
                _context.Entry(productType).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
           
           
        }

        // method to get all productTypes

        public async Task<List<ProductType>> GetProductTypes()
        {
            return await _context.ProductType.ToListAsync();
        }
        public async Task<List<SelectListItem>> GetProductTypesTolist()
        {

            return await _context.ProductType.Select(i => new SelectListItem
             {
                 Value = i.Id.ToString(),
                 Text = i.Name
             }).ToListAsync();

        }


        // method to get all productType by id

        public async Task<ProductType> GetProductType(int id)
        {
            return await _context.ProductType.FirstOrDefaultAsync(z => z.Id == id);
        }

        // method to update a ProductType

        

        public async Task<ProductType> UpdateProductType(int id, ProductType productType)
        {
            _context.Entry(productType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return productType;
         }

      
    }
}
