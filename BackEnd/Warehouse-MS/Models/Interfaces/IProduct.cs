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
        Task<List<Product>> SortByDate(bool flag);
        Task<List<Product>> SortByExpirationDate(bool flag);
        Task<List<Product>> SortBySize(bool flag);
        Task<List<Product>> SortByWeight(bool flag);

        Task<List<Product>> FilterByProductType(string input);
        Task<List<Product>> FilterByStorageType(string input);
        Task<Product> GenerateBarCode(int Id);
        Task<Product> GetByBarCode(string barcode);

        Task<List<Product>> Packing(int id, int newWeight, int newSize);
    }
}
