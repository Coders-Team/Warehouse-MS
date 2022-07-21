using System;
using Xunit;
using Warehouse_MS;
using System.Threading.Tasks;
using Warehouse_MS.Models.Services;
using Warehouse_MSTest;


namespace Basket_Store_Test
{
    public class WarehouseDemoUnitTest : Mock
    {
        [Fact]
        public async Task Test1()
        {
            var Warehouse = await CreateAndSaveTestWarehouse();
            var product = await CreateAndSaveTestProduct();

            var Productservice = new ProductServices(_db);

            // Act
            await Productservice.FilterByProductType(product.Name);

            // Assert
            var actualProduct = await Productservice.GetProduct(product.Id);

          //  Assert.Contains(actualProduct.Name, a => a.Id == product.Id);

            // Act
            await Productservice.DeleteProduct( product.Id);

            // Assert
            actualProduct = await Productservice.GetProduct(product.Id);

           // Assert.DoesNotContain(actualProduct., a => a.Id == product.Id);
        }
        [Fact]
        public async Task AddandRemoveWarehouse()
        {
            var store = await CreateAndSaveTestStorage();
            var product = await CreateAndSaveTestProduct();


            var storage = new WarehouseService(_db);

            // Act
          //  await storage.AddProducteToStorage(store.Id, product.Id);

            // Assert
            var actualStorage = await storage.GetWarehouse(store.Id);

            Assert.Contains(actualStorage.Storages, a => a.Id == product.Id);

            // Act
         //   await storage.Create(product.Id);

            // Assert
            actualStorage = await storage.GetWarehouse(store.Id);

           // Assert.DoesNotContain(actualStorage.Products, a => a.Id == product.Id);
        }
    }
}