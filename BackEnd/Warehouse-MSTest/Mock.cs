using Warehouse_MS.Data;
using Warehouse_MS.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Warehouse_MSTest
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly WarehouseDBContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new WarehouseDBContext(
                new DbContextOptionsBuilder<WarehouseDBContext>()
                    .UseSqlite(_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }


        protected async Task<Warehouse> CreateAndSaveTestWarehouse()
        {
            var cart = new Warehouse { SizeInUnit = 500, Description = "open", Location = "1123 west", Name = "Clothes"  };
            _db.Warehouse.Add(cart);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, cart.Id); // Sanity check
            return cart;
        }

        protected async Task<Product> CreateAndSaveTestProduct()
        {
            var product = new Product { Name = "Iphone", Weight =170 , SizeInUnit = 2, Description = "Iphone 13 pro", ProductTypeId = 1, StorageId = 1 };
            _db.Product.Add(product);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, product.Id); // Sanity check
            return product;
        }

        protected async Task<Storage> CreateAndSaveTestStorage()
        {
            var favourite = new Storage { };
            _db.Storage.Add(favourite);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, favourite.Id); // Sanity check
            return favourite;
        }
      
    }
}
