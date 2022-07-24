using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Warehouse_MS.Auth.Models;
using Warehouse_MS.Models;

namespace Warehouse_MS.Data
{
    public class WarehouseDBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<StorageType> StorageType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        //Join Table
        public DbSet<UserWarehouse> UserWarehouse { get; set; }

        public WarehouseDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<Transaction>().HasMany(a=> a.Product)
            modelBuilder.Entity<Transaction>()
         .HasOne(b => b.Product)
         .WithMany(a => a.Transaction)
         .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<Product>()
            //.HasOne(b => b.)
            //.WithMany(a => a.)
            //.OnDelete(DeleteBehavior.NoAction);




            modelBuilder.Entity<Warehouse>().HasData(
                new Warehouse { Id = 1, Name = "Warehouse1", Location = "Amman", SizeInUnit = 100, Description = " ...." },
                new Warehouse { Id = 2, Name = "Warehouse2", Location = "aqaba", SizeInUnit = 50, Description = " ...." },
                new Warehouse { Id = 3, Name = "Warehouse3", Location = "Irbid", SizeInUnit = 150, Description = " ...." },
                new Warehouse { Id = 4, Name = "Warehouse4", Location = "zarqa", SizeInUnit = 200, Description = " ...." });

            modelBuilder.Entity<ProductType>().HasData(
                new ProductType { Id = 1, Name = "food", Description = "...." },
                new ProductType { Id = 2, Name = "metals", Description = "...." },
                new ProductType { Id = 3, Name = "Cleaning materials", Description = "...." },
                new ProductType { Id = 4, Name = "raw material", Description = "...." }
                );
            modelBuilder.Entity<StorageType>().HasData(

                new ProductType { Id = 1, Name = "low temperature", Description = "...." },
                new ProductType { Id = 2, Name = "on shelves", Description = "...." },
                new ProductType { Id = 3, Name = "on the floor", Description = "...." },
                new ProductType { Id = 4, Name = "recycle area", Description = "...." }
                );


            modelBuilder.Entity<Storage>().HasData(
                new Storage { Id = 1, Name = "Storage1", WarehouseId = 1, StorageTypeId = 1, LocationInWarehouse = "floor 1 west", SizeInUnit = 15, Description = " ...." },
                new Storage { Id = 2, Name = "Storage2", WarehouseId = 1, StorageTypeId = 2, LocationInWarehouse = "floor 2 east", SizeInUnit = 30, Description = " ...." },
                new Storage { Id = 3, Name = "Storage3", WarehouseId = 1, StorageTypeId = 3, LocationInWarehouse = "floor 1 behind the fridge ", SizeInUnit = 55, Description = " ...." },
                new Storage { Id = 4, Name = "Storage4", WarehouseId = 2, StorageTypeId = 3, LocationInWarehouse = "floor 1 production section", SizeInUnit = 25, Description = " ...." },
                new Storage { Id = 5, Name = "Storage5", WarehouseId = 2, StorageTypeId = 4, LocationInWarehouse = "floor 2 between section a and section t", SizeInUnit = 25, Description = " ...." },
                new Storage { Id = 6, Name = "Storage6", WarehouseId = 3, StorageTypeId = 3, LocationInWarehouse = "floor 1 south", SizeInUnit = 50, Description = " ...." },
                new Storage { Id = 7, Name = "Storage7", WarehouseId = 4, StorageTypeId = 2, LocationInWarehouse = "floor 1 west", SizeInUnit = 50, Description = " ...." }


                );
            modelBuilder.Entity<Product>().HasData(
                  new Product { Id = 1, Name = "Product1", Date = new DateTime(2022, 5, 2), ExpiredDate = new DateTime(2024, 5, 26), Weight = 100, StorageTypeId = 1, StorageId = 1, ProductTypeId = 1, SizeInUnit = 5, BarcodeNum = null, Photo = null, Description = " ...." },
                  new Product { Id = 2, Name = "Product2", Date = new DateTime(2020, 7, 2), ExpiredDate = new DateTime(2022, 5, 15), Weight = 200, StorageTypeId = 1, StorageId = 1, ProductTypeId = 4, SizeInUnit = 3, BarcodeNum = null, Photo = null, Description = " ...." },
                  new Product { Id = 3, Name = "Product3", Date = new DateTime(2021, 5, 2), ExpiredDate = new DateTime(2023, 5, 25), Weight = 150, StorageTypeId = 1, StorageId = 1, ProductTypeId = 1, SizeInUnit = 5, BarcodeNum = null, Photo = null, Description = " ...." },
                  new Product { Id = 4, Name = "Product4", Date = new DateTime(2019, 5, 2), ExpiredDate = new DateTime(2021, 5, 24), Weight = 104, StorageTypeId = 2, StorageId = 2, ProductTypeId = 2, SizeInUnit = 1, BarcodeNum = null, Photo = null, Description = " ...." },
                  new Product { Id = 5, Name = "Product5", Date = new DateTime(2015, 5, 2), ExpiredDate = new DateTime(2017, 5, 5), Weight = 430, StorageTypeId = 2, StorageId = 2, ProductTypeId = 1, SizeInUnit = 10, BarcodeNum = null, Photo = null, Description = " ...." },
                  new Product { Id = 6, Name = "Product6", Date = new DateTime(2016, 5, 2), ExpiredDate = new DateTime(2018, 5, 4), Weight = 110, StorageTypeId = 3, StorageId = 3, ProductTypeId = 3, SizeInUnit = 2, BarcodeNum = null, Photo = null, Description = " ...." },
                  new Product { Id = 7, Name = "Product7", Date = new DateTime(2010, 5, 2), ExpiredDate = new DateTime(2012, 5, 1), Weight = 300, StorageTypeId = 4, StorageId = 5, ProductTypeId = 4, SizeInUnit = 15, BarcodeNum = null, Photo = null, Description = " ...." }
                 );

            modelBuilder.Entity<UserWarehouse>().HasKey(
           UserWarehouse => new { UserWarehouse.UserId, UserWarehouse.WarehouseId }
           );


            SeedRole(modelBuilder, "Admin");
            SeedRole(modelBuilder, "supervisor");


        }
        private void SeedRole(ModelBuilder modelBuilder, string roleName)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };
            modelBuilder.Entity<IdentityRole>().HasData(role);
        }
    }
}
