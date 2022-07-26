using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse_MS.Models;

namespace Warehouse_MS.Models.Interfaces
{
    public interface  IStorageType
    {
        // method to get all StorageType
        Task<List<StorageType>> GetStorageTypes();

        Task<List<SelectListItem>> GetStorageTypesTolist();

        // method to get specific StorageType by id
        Task<StorageType> GetStorageType(int id);

        
        // method to create new StorageType
        Task<StorageType> Create(StorageType storageType);

        
        // method to update a StorageType
        Task<StorageType> UpdateStorageType(int id, StorageType storageType);
       
        
        // method to Delete a StorageType
        Task Delete(int id);

    }
}
