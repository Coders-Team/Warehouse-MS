using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse_MS.Models;

namespace FastMarket.Models.Interfaces
{
    public interface IProductType
    {
        // method to get all ProductType
        Task<List<ProductType>> GetProductTypes();
        
        // method to get specific ProductType by id
        Task<ProductType> GetProductType(int id);

        // method to create new ProductType
        Task<ProductType> Create(ProductType productType);

        // method to update a ProductType
        Task<ProductType> UpdateProductType(int id, ProductType productType);

        // method to Delete a ProductType
        Task Delete(int id);




    }
}
