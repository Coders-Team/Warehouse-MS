using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse_MS.Data;
using Warehouse_MS.Models.DTO;
using Warehouse_MS.Models.Interfaces;

namespace Warehouse_MS.Models.Services
{
    public class StorageService : IStorage
    {

        private readonly WarehouseDBContext _context;

        public StorageService(WarehouseDBContext context)
        {
            _context = context;
        }

        public async Task<StorageDto> Create(Storage storage)
        {
            _context.Entry(storage).State = EntityState.Added;
            await _context.SaveChangesAsync();
            StorageDto storageDto = new StorageDto
            {
                Id = storage.Id,
                Name = storage.Name,
                SizeInUnit = storage.SizeInUnit,
                LocationInWarehouse = storage.LocationInWarehouse,
                Description = storage.Description
            };
            return storageDto;
        }
        public async Task<StorageDto> GetStorage(int id)
        {
            return await _context.Storage.Select(storage => new StorageDto
            {
                Id = storage.Id,
                Name = storage.Name,
                SizeInUnit = storage.SizeInUnit,
                LocationInWarehouse = storage.LocationInWarehouse,
                Description = storage.Description,
                WarehouseId = storage.WarehouseId,
                StorageTypeId = storage.StorageTypeId
            }).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<StorageDto>> GetStorages()
        {
            return await _context.Storage.Select(storage => new StorageDto
            {
                Id = storage.Id,
                Name = storage.Name,
                SizeInUnit = storage.SizeInUnit,
                LocationInWarehouse = storage.LocationInWarehouse,
                Description = storage.Description,
                WarehouseId = storage.WarehouseId,
                StorageTypeId = storage.StorageTypeId
            }).ToListAsync();
        }

        public async Task<Storage> UpdateStorage(int id, Storage storage)
        {
            _context.Entry(storage).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return storage;
        }

        public async Task Delete(int id)
        {
            Storage storage = await _context.Storage.FindAsync(id);
            _context.Entry(storage).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
