using Microsoft.EntityFrameworkCore;
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
    }
}
