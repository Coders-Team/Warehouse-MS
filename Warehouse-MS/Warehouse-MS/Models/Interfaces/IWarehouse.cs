using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse_MS.Models.DTO;

namespace Warehouse_MS.Models.Interfaces
{
    public interface IWarehouse
    {
        // method to get all Warehouses
        Task<List<WarehouseDto>> GetWarehouses();

        Task<List<SelectListItem>> GetWarehouseTolist();

        // method to get specific Warehouse by id
        Task<WarehouseDto> GetWarehouse(int id);

        // method to create new Warehouse
        Task<WarehouseDto> Create(Warehouse warehouse);

        // method to update a Warehouse
        Task<Warehouse> UpdateWarehouse(int id, Warehouse warehouse);

        // method to Delete a Warehouse
        Task Delete(int id);
        Task<List<WarehouseDto>> GetUserWarehouse(string id);

        public Task<Storage> AddStorageToWarehouse(StorageDto storageDto);
    }
}
