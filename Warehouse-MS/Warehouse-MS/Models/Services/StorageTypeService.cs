﻿using Warehouse_MS.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse_MS.Data;
using Warehouse_MS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Warehouse_MS.Models.Services
{
    public class StorageTypeService : IStorageType
    {

        private readonly WarehouseDBContext _context;


        public StorageTypeService(WarehouseDBContext context)
        {
            _context = context;
        }



        // method to create new StorageType

        public async Task<StorageType> Create(StorageType storageType)
        {
            _context.Entry(storageType).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return storageType;
        }

        // method to Delete a StorageType

        public async Task Delete(int id)
        {


            StorageType storageType = await _context.StorageType.FindAsync(id);


            _context.Entry(storageType).State = EntityState.Deleted;

            await _context.SaveChangesAsync();


        }

        // method to get all StorageType

        public async Task<List<StorageType>> GetStorageTypes()
        {
            return await _context.StorageType.ToListAsync();
        }

        public async Task<List<SelectListItem>> GetStorageTypesTolist()
        {

            return await _context.StorageType.Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.Name
            }).ToListAsync();

        }

        // method to get all StorageType by id

        public async Task<StorageType> GetStorageType(int id)
        {
            return await _context.StorageType.FirstOrDefaultAsync(z => z.Id == id);
        }

        // method to update a StorageType



        public async Task<StorageType> UpdateStorageType(int id, StorageType storageType)
        {
            _context.Entry(storageType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return storageType;
        }
    }
}
