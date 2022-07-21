using Microsoft.EntityFrameworkCore;
using Warehouse_MS.Data;
using Warehouse_MS.Models;
using Xunit;
using System;

namespace Warehouse_MSTest
{
    public class WarehouseDemoUnitTest : Mock
    {



        [Fact]
        public void CanGetProduct()
        {

            Product product = new Product();
            product.Name = "Iphone 13";

            Assert.Equal("Iphone 13", product.Name);
        }
        [Fact]
        public void CanSetProduct()
        {

            Product product = new Product()
            {
                Name = "Iphone 13",
                SizeInUnit = 2,
            };
            product.Name = "Iphone 13 Pro Max";

            Assert.Equal("Iphone 13 Pro Max", product.Name);
        }
        [Fact]
        public async void CrudProductInDB()
        {

            DbContextOptions<WarehouseDBContext> options =
            new DbContextOptionsBuilder<WarehouseDBContext>().UseInMemoryDatabase("DbCanSave").Options;

            using (WarehouseDBContext context = new WarehouseDBContext(options))
            {
                Product product = new Product();
                product.Name = "Iphone 13 Pro Max";
                product.SizeInUnit = 12;


                context.Product.Add(product);
                context.SaveChanges();
                var productName = await context.Product.FirstOrDefaultAsync(x => x.Name == product.Name);

                Assert.Equal("Iphone 13 Pro Max", productName.Name);

                product.Name = "Update Product";
                context.Product.Update(product);
                context.SaveChanges();
                var updatedProduct = await context.Product.FirstOrDefaultAsync(x => x.Name == product.Name);
                Assert.Equal("Update Product", updatedProduct.Name);

                context.Product.Remove(product);
                context.SaveChanges();
                var deletedProduct = await context.Product.FirstOrDefaultAsync(x => x.Name == product.Name);
                Assert.True(deletedProduct == null);
            }
        }

        [Fact]
        public void CanGetStorage()
        {
            //Arrange
            Storage storage = new Storage();
            storage.Name = "Mobiles";

            //Assert
            Assert.Equal("Mobiles", storage.Name);
        }
        [Fact]
        public void CanSetStorage()
        {
            //Arrange
            Storage Storage = new Storage()
            {
                Name = "Mobiles",

            };
            Storage.Name = "Mobile";
            //Assert
            Assert.Equal("Mobile", Storage.Name);
        }
        [Fact]
        public async void CrudStorageInDB()
        {
            //Arrange
            //setup our DB
            //set values

            DbContextOptions<WarehouseDBContext> options =
            new DbContextOptionsBuilder<WarehouseDBContext>().UseInMemoryDatabase("DbCanSave").Options;

            //Act
            using (WarehouseDBContext context = new WarehouseDBContext(options))
            {
                Storage Storage = new Storage();
                Storage.Name = "Test";


                ////Act

                context.Storage.Add(Storage);
                context.SaveChanges();

                var StorageName = await context.Storage.FirstOrDefaultAsync(x => x.Name == Storage.Name);

                //Assert
                Assert.Equal("Test", StorageName.Name);

                //UPDATE
                Storage.Name = "Update Storage";
                context.Storage.Update(Storage);
                context.SaveChanges();

                var updatedStorage = await context.Storage.FirstOrDefaultAsync(x => x.Name == Storage.Name);

                Assert.Equal("Update Storage", updatedStorage.Name);

                //DELETE
                context.Storage.Remove(Storage);
                context.SaveChanges();

                var delete = await context.Storage.FirstOrDefaultAsync(x => x.Name == Storage.Name);

                Assert.True(delete == null);
            }

        }

        [Fact]
        public void CanGetWarehous()
        {
            //Arrange
            Warehouse storage = new Warehouse();
            storage.Name = "Mobiles";

            //Assert
            Assert.Equal("Mobiles", storage.Name);
        }
        [Fact]
        public void CanSetWarehous()
        {
            //Arrange
            Warehouse Storage = new Warehouse()
            {
                Name = "Mobiles",

            };
            Storage.Name = "Mobile";
            //Assert
            Assert.Equal("Mobile", Storage.Name);
        }
        [Fact]
        public async void CrudproductTypeInDB()
        {
            //Arrange
            //setup our DB
            //set values

            DbContextOptions<WarehouseDBContext> options =
            new DbContextOptionsBuilder<WarehouseDBContext>().UseInMemoryDatabase("DbCanSave").Options;

            //Act
            using (WarehouseDBContext context = new WarehouseDBContext(options))
            {
                ProductType productType = new ProductType();
                productType.Name = "Test";


                ////Act

                context.ProductType.Add(productType);
                context.SaveChanges();

                var warehouseName = await context.Storage.FirstOrDefaultAsync(x => x.Name == productType.Name);

                //Assert
                Assert.Equal("Test", warehouseName.Name);

                //UPDATE
                productType.Name = "Update ProductType";
                context.ProductType.Update(productType);
                context.SaveChanges();

                var updatedwarehouse = await context.Storage.FirstOrDefaultAsync(x => x.Name == productType.Name);

                Assert.Equal("Update ProductType", updatedwarehouse.Name);

                //DELETE
                context.ProductType.Remove(productType);
                context.SaveChanges();

                var delete = await context.Warehouse.FirstOrDefaultAsync(x => x.Name == productType.Name);

                Assert.True(delete == null);
            }

        }

    }
}