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
    public class StorageService : IStorage
    {

        private readonly WarehouseDBContext _context;
        private readonly ITransaction _transaction;
        private readonly IProduct _product;

        public StorageService(WarehouseDBContext context, ITransaction transaction, IProduct product)
        {
            _context = context;
            this._transaction = transaction;
            this._product = product;
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
                StorageTypeId = storage.StorageTypeId,
                Products = storage.Products.Select(product => new ProductDto2
                {
                    Id = product.Id,
                    Name = product.Name,
                    SizeInUnit = product.SizeInUnit,
                    StorageId = product.StorageId,
                    ProductTypeId = product.ProductTypeId,
                    StorageTypeId = product.StorageTypeId,
                    Date = product.Date,
                    ExpiredDate = product.ExpiredDate,
                    Weight = product.Weight,
                    BarcodeNum = product.BarcodeNum,
                    Photo = product.Photo,
                    Description = product.Description
                }).ToList()

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
                StorageTypeId = storage.StorageTypeId,
                Products = storage.Products.Select(product => new ProductDto2
                {
                    Id = product.Id,
                    Name = product.Name,
                    SizeInUnit = product.SizeInUnit,
                    StorageId = product.StorageId,
                    ProductTypeId = product.ProductTypeId,
                    StorageTypeId = product.StorageTypeId,
                    Date = product.Date,
                    ExpiredDate = product.ExpiredDate,
                    Weight = product.Weight,
                    BarcodeNum = product.BarcodeNum,
                    Photo = product.Photo,
                    Description = product.Description
                }).ToList()
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

        public async Task<List<StorageDto>> GetStoragesbyType(int storageTypeId)
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
            }).Where(x => x.StorageTypeId == storageTypeId).ToListAsync();
        }

        public async Task<Product> AddProducteToStorage(ProductDto productDto)
        {
            int? newSize = await SizeisOk(productDto.SizeInUnit, productDto.StorageId);

            if (newSize == null)
            {
                return null;
            }
            Product product = new Product()
            {
                Name = productDto.Name,
                StorageTypeId = await GetStorageTypeId(productDto.StorageId),
                StorageId = productDto.StorageId,
                ProductTypeId = productDto.ProductTypeId,
                Date = productDto.Date,
                ExpiredDate = productDto.ExpiredDate,
                SizeInUnit = (int)newSize,
                Weight = productDto.Weight,
                BarcodeNum = await _product.GenerateBarCode(),
                Photo = productDto.Photo,
                Description = productDto.Description




            };

            _context.Entry(product).State = EntityState.Added;
            await _context.SaveChangesAsync();


            TransactionDto transactionDto = new TransactionDto
            {
                OldLocation = null,
                NewLocation = product.Storage.Name,
                Type = "add",
                ProductId = product.Id,

            };

            await _transaction.Create(transactionDto);


            return product;
        }
        /// <summary>
        /// to get storage type by storageId
        /// </summary>
        /// <param name="storageId"></param>
        /// <returns></returns>
        private async Task<int> GetStorageTypeId(int storageId)
        {
            Storage storage = await _context.Storage.FindAsync(storageId);

            return storage.StorageTypeId;
        }

        /// <summary>
        ///  to chech if the total product size is less than storage
        /// </summary>
        /// <param name="sizeInUnit"></param>
        /// <param name="storageId"></param>
        /// <returns></returns>
        private async Task<int?> SizeisOk(int sizeInUnit, int storageId)
        {
            Storage storage = await _context.Storage.FindAsync(storageId);
            if (storage == null)
            {
                return null;
            }

            int totalStze = 0;
            if (storage.Products != null)
            {
                foreach (Product product in storage.Products)
                {
                    totalStze += product.SizeInUnit;

                }

            }
            if (totalStze + sizeInUnit > storage.SizeInUnit)
            {
                return null;
            }
            return sizeInUnit;



        }

        public async Task<Product> RemoveProductStorage(int productId)
        {
            Product product = await _context.Product.FirstOrDefaultAsync(c => c.Id == productId);

            if (product == null)
            { return null; }
            var OldLocation = await _context.Storage.FindAsync(product.StorageId);
            _context.Entry(product).State = EntityState.Deleted;

            await _context.SaveChangesAsync();

            TransactionDto transactionDto = new TransactionDto
            {
                OldLocation = OldLocation.Name,
                NewLocation = null,
                Type = "put-away",
                ProductId = productId,
            };

            await _transaction.Create(transactionDto);

            return product;

        }

        public async Task<Product> UpdateProduct(int id, ProductRelocateDto productRelocateDto)
        {
            Product product = await _context.Product.FirstOrDefaultAsync(c => c.Id == productRelocateDto.ProductId);
            if (product == null)
            {
                return null;
            }

            int? newSize = await SizeisOk(product.SizeInUnit, productRelocateDto.NewStorageId);

            if (newSize == null)
            {
                return null;
            }
            var OldLocation = await _context.Storage.FindAsync(product.StorageId);
            product.StorageId = productRelocateDto.NewStorageId;
            var newLocation = await _context.Storage.FindAsync(product.StorageId);

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            TransactionDto transactionDto = new TransactionDto
            {
                OldLocation = OldLocation.Name,
                NewLocation = newLocation.Name,
                Type = "Relocate",
                ProductId = product.Id,
            };

            await _transaction.Create(transactionDto);



            return product;

        }
    }
}
