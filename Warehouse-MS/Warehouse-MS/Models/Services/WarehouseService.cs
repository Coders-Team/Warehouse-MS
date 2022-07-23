using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse_MS.Data;
using Warehouse_MS.Models.DTO;
using Warehouse_MS.Models.Interfaces;

namespace Warehouse_MS.Models.Services
{
    public class WarehouseService : IWarehouse
    {
        private readonly WarehouseDBContext _context;

        public WarehouseService(WarehouseDBContext context)
        {
            _context = context;
        }

        public async Task<WarehouseDto> Create(Warehouse warehouse)
        {
            _context.Entry(warehouse).State = EntityState.Added;
            await _context.SaveChangesAsync();
            WarehouseDto warehouseDto = new WarehouseDto
            {
                Id = warehouse.Id,
                Name = warehouse.Name,
                SizeInUnit = warehouse.SizeInUnit,
                Location = warehouse.Location,
                Description = warehouse.Description

            };
            return warehouseDto;
        }

        public async Task<WarehouseDto> GetWarehouse(int id)
        {
            return await _context.Warehouse.Select(warehouse => new WarehouseDto
            {
                Id = warehouse.Id,
                Name = warehouse.Name,
                SizeInUnit = warehouse.SizeInUnit,
                Location = warehouse .Location,
                Description = warehouse.Description,
                UserId=warehouse.UserId,
                Storages = warehouse.Storages.Select(s => new StorageDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    SizeInUnit = s.SizeInUnit,
                    LocationInWarehouse = s.LocationInWarehouse,
                    Description = s.Description,
                    WarehouseId = s.WarehouseId,
                    StorageTypeId = s.StorageTypeId
                }).ToList()
            }).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<WarehouseDto>> GetWarehouses()
        {
            return await _context.Warehouse.Select(warehouse => new WarehouseDto
            {
                Id = warehouse.Id,
                Name = warehouse.Name,
                SizeInUnit = warehouse.SizeInUnit,
                Location = warehouse.Location,
                Description = warehouse.Description,
                UserId = warehouse.UserId,
                Storages = warehouse.Storages.Select(s => new StorageDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    SizeInUnit = s.SizeInUnit,
                    LocationInWarehouse = s.LocationInWarehouse,
                    Description = s.Description,
                    WarehouseId = s.WarehouseId,
                    StorageTypeId = s.StorageTypeId
                }).ToList()
            }).ToListAsync();
        }

        public async Task<Warehouse> UpdateWarehouse(int id, Warehouse warehouse)
        {
            _context.Entry(warehouse).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return warehouse;
        }

        public async Task Delete(int id)
        {
            Warehouse warehouse = await _context.Warehouse.FindAsync(id);

            

            _context.Entry(warehouse).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }

        public async Task<Storage> AddStorageToWarehouse(StorageDto storageDto)
        {
            int? newSize = SizeisOk(storageDto.SizeInUnit, storageDto.WarehouseId).Result;

            if (newSize== null)
            {
                return null;
            }

            Storage storage = new Storage()
            {
                Name = storageDto.Name,
                StorageTypeId = storageDto.StorageTypeId,
                WarehouseId = storageDto.WarehouseId,
                SizeInUnit =(int) newSize,
                LocationInWarehouse = storageDto.LocationInWarehouse,
                Description = storageDto.Description


            };

            _context.Entry(storage).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return storage;

        }

      


        /// <summary>
        /// to chech if the total storage size is less than warehouse 
        /// </summary>
        /// <param name="sizeInUnit"></param>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        private async Task< int?> SizeisOk(int sizeInUnit, int warehouseId)
        {

            WarehouseDto warehouse = await GetWarehouse(warehouseId);
            if (warehouse == null)
            {
                return null;
            }

            int totalStze = 0;
            foreach (StorageDto storge in warehouse.Storages)
            {
                totalStze += storge.SizeInUnit;
                
            }
            if (totalStze+sizeInUnit> warehouse.SizeInUnit)
            {
                return null;
            }
            return sizeInUnit;

        }

        public async Task AddWarehouseToUser(int warehouseId, string userId)
        {
            UserWarehouse userWarehouse = new UserWarehouse
            {
                WarehouseId = warehouseId,
                UserId = userId
            };

            _context.Entry(userWarehouse).State = EntityState.Added;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveWarehouseToUser(int warehouseId, string userId)
        {
            UserWarehouse userWarehouse = await _context.UserWarehouse
                                            .Where(UW => UW.WarehouseId == warehouseId && UW.UserId == userId)
                                            .FirstAsync();
            _context.Entry(userWarehouse).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
