using Microsoft.EntityFrameworkCore;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Warehouse_MS.Data;
using Warehouse_MS.Models.DTO;
using Warehouse_MS.Models.Interfaces;

namespace Warehouse_MS.Models.Services
{
    public class ProductServices : IProduct
    {
        private readonly WarehouseDBContext _context;
        private readonly ITransaction _transaction;

        public ProductServices(WarehouseDBContext context, ITransaction transaction)
       {
            _context = context;
            this._transaction = transaction;
        }

    public async Task<ProductDto> Create(ProductDto productDto) {

            int? newSize = await SizeisOk(productDto.SizeInUnit, productDto.StorageId);

            if (newSize == null)
            {
                return null;
            }

            Product product = new Product() {
                Name = productDto.Name,
                ProductTypeId = productDto.ProductTypeId,
                StorageTypeId = productDto.StorageTypeId,
                StorageId = productDto.StorageId,
                Weight =productDto.Weight,
                Date=DateTime.Now,
                ExpiredDate = productDto.ExpiredDate,//ToString("MM/dd/yyyy"),
                BarcodeNum = GenerateBarCode().Result,
                SizeInUnit = (int)newSize,
                Photo = null,
                Description =productDto.Description
            };

            productDto.BarcodeNum = product.BarcodeNum;
            _context.Entry(product).State = EntityState.Added;
            await _context.SaveChangesAsync();

            product.Photo= QRCode1("http://localhost:3639/Products/Details/" + product.Id);

            _context.Entry(product).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            TransactionDto transactionDto = new TransactionDto
            {
                OldLocation = "same location",
                NewLocation = "same location",
                //product.Storage.Name
                Type = "add",
                ProductId = product.Id,

            };

            await _transaction.Create(transactionDto);


            return productDto;
            
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

        public async Task DeleteProduct(int Id)
        {
            Product product = await GetProduct(Id);

            _context.Entry(product).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }

        public async Task<Product> GetProduct(int Id)
        {
            Product product = await _context.Product.FindAsync(Id);
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await _context.Product.ToListAsync();
            return products;
        }

        public async Task<Product> UpdateProduct(int Id, Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();



            TransactionDto transactionDto = new TransactionDto()
            {
                OldLocation = "same location",
                NewLocation = "same location",
                Type = "Update",
                ProductId = product.Id,

            };

            await _transaction.Create(transactionDto);

            return product;


        }


        public async Task<List<Product>> SortByDate(bool flag)
        {
            if (flag)
            {
                var products = await _context.Product.OrderBy(p => p.Date).ToListAsync();
                return products;

            }
            else
            {
                var products = await _context.Product.OrderByDescending(p => p.Date).ToListAsync();
                return products;

            }
        }

        public async Task<List<Product>> SortByExpirationDate(bool flag)
        {
            if (flag)
            {
                var products = await _context.Product.OrderBy(p => p.ExpiredDate).ToListAsync();
                return products;

            }
            else
            {
                var products = await _context.Product.OrderByDescending(p => p.ExpiredDate).ToListAsync();
                return products;

            }
        }

        public async Task<List<Product>> SortByWeight(bool flag)
        {
            if (flag)
            {
                var products = await _context.Product.OrderBy(p => p.Weight).ToListAsync();
                return products;

            }
            else
            {
                var products = await _context.Product.OrderByDescending(p => p.Weight).ToListAsync();
                return products;

            }
        }

        public async Task<List<Product>> SortBySize(bool flag)
        {
            if (flag)
            {
                var products = await _context.Product.OrderBy(p => p.SizeInUnit).ToListAsync();
                return products;

            }
            else
            {
                var products = await _context.Product.OrderByDescending(p => p.SizeInUnit).ToListAsync();
                return products;

            }
        }



        public async Task<List<Product>> FilterByProductType(string input)
        {

            var products = await _context.Product.Where(p => p.ProductType.Name == input).ToListAsync();
            return products;

        }


        public async Task<List<Product>> FilterByStorageType(string input)
        {

            var products = await _context.Product.Where(p => p.StorageType.Name == input).ToListAsync();
            return products;

        }


        //public async Task<Product> GenerateBarCode(int Id)
        //{

        //    Product product = await GetProduct(Id);
        //    Random rand = new Random();
        //    int num = rand.Next(100000, 999999);
        //    string barcode = "BAR" + num;

        //    List<Product> products = await GetProducts();

        //    var barcodes = products.Select(p => p.BarcodeNum);

        //    while (barcodes.Contains(barcode))
        //    {
        //        num = rand.Next(100000, 999999);
        //        barcode = "BAR" + num;

        //    }

        //    product.BarcodeNum = barcode;

        //    Product updatedProduct = await UpdateProduct(Id, product);

        //    return updatedProduct;
        //}
        public string QRCode1(string qrcode)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrcode, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                using (Bitmap bitMap = qrCode.GetGraphic(20))
                {
                    bitMap.Save(ms, ImageFormat.Png);
                    var x = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                    return x;
                }
            }

            return null;
        }

    

public async Task<string> GenerateBarCode()
        {

            Random rand = new Random();
            int num = rand.Next(100000, 999999);
            string barcode = "BAR" + num;

            List<Product> products = await GetProducts();

            var barcodes = products.Select(p => p.BarcodeNum);

            while (barcodes.Contains(barcode))
            {
                num = rand.Next(100000, 999999);
                barcode = "BAR" + num;

            }
            return barcode;
        }

        public async Task<Product> GetByBarCode(string barcode)
        {
             Product product = await _context.Product.FirstOrDefaultAsync(x=>x.BarcodeNum== barcode);
            if (product == null)
            {
                return null;
            }

            //List<Product> products = await GetProducts();
            //Product product = null;
            //foreach (Product item in products)
            //{
            //    if (item.BarcodeNum == barcode)
            //    {
            //        product = item;
            //    }
            //}

            return product;
        }

        public async Task<List<Product>> Packing(int id, int newWeight, int newSize)
        {
            Product product = await GetProduct(id);

            if (product.Weight < newWeight || product.SizeInUnit < newSize)
            {
                return null;
            }

            product.Weight = product.Weight - newWeight;
            product.SizeInUnit = product.SizeInUnit - newSize;

            await UpdateProduct(id, product);

            ProductDto newProduct = new ProductDto { Photo = product.Photo, Name = product.Name + " After packing", SizeInUnit = newSize, Weight = newWeight, Date = product.Date, ExpiredDate = product.ExpiredDate, Description = product.Description,  ProductTypeId = product.ProductTypeId, StorageId = product.StorageId, StorageTypeId = product.StorageTypeId };
            await Create(newProduct);

            List<Product> products = new List<Product>();
            products.Add(product);
            products.Add(GetByBarCode(newProduct.BarcodeNum).Result);

            TransactionDto transactionDto = new TransactionDto
            {
                OldLocation = "same location",
                NewLocation = "same location",
                Type = "Packing",
                ProductId = product.Id,

            };

            await _transaction.Create(transactionDto);



            return products;

        }
    }
}
