using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse_MS.Models.DTO;

namespace Warehouse_MS.Models.Interfaces
{
    public interface IStorage
    {
        // method to get all Storages
       // Task<List<StorageDto>> GetStorages();
        Task<List<WarehouseDto>> GetStorages(string WarehouseId);

        Task<List<SelectListItem>> GetStoragesTolist();

        // method to get specific Storage by id
        Task<StorageDto> GetStorage(int id);

        // method to create new Storage
        Task<Storage> Create(StorageDto storageDto);

        // method to update a Storage
        Task<Storage> UpdateStorage(int id, Storage storage);

        // method to Delete a Storage
        Task Delete(int id);


        Task<List<StorageDto>> GetStoragesbyType(int storageTypeId);



        public Task<Product> AddProducteToStorage(ProductDto productDto);
        public Task<Product> RemoveProductStorage(int productId);

        Task<Product> UpdateProduct(int id, ProductRelocateDto productRelocateDto);



    }
}
