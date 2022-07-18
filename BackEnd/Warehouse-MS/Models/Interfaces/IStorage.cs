using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse_MS.Models.DTO;

namespace Warehouse_MS.Models.Interfaces
{
    public interface IStorage
    {
        // method to get all Storages
        Task<List<StorageDto>> GetStorages();

        // method to get specific Storage by id
        Task<StorageDto> GetStorage(int id);

        // method to create new Storage
        Task<StorageDto> Create(Storage storage);

        // method to update a Storage
        Task<Storage> UpdateStorage(int id, Storage storage);

        // method to Delete a Storage
        Task Delete(int id);
    }
}
