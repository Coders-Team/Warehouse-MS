using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse_MS.Models.Interfaces
{
    public interface IProduct
    {
        Task<Product> Create(Product product);
        Task<Product> GetProduct(int Id);
        Task<List<Product>> GetProducts();
        Task<Product> UpdateProduct(int Id, Product product);
        Task DeleteProduct(int Id);
    }
}
