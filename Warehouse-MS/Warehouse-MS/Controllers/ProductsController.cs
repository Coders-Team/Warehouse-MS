﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse_MS.Models;
using Warehouse_MS.Models.DTO;
using Warehouse_MS.Models.Interfaces;

namespace Warehouse_MS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProduct _product;
        private readonly IProductType _productType;
        private readonly IStorageType _storageType;
        private readonly IStorage _storage;

        public ProductsController(IProduct product,IProductType productType ,IStorageType storageType,IStorage storage)
        {
            _product = product;
            this._productType = productType;
            this._storageType = storageType;
            this._storage = storage;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _product.GetProducts();

            return View(products);
        }


        // GET: Products/Details?id=5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _product.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
          
            ViewBag.ProductTypes = await _productType.GetProductTypesTolist();
            ViewBag.StorageTypes = await _storageType.GetStorageTypesTolist();
            ViewBag.Storages = await _storage.GetStoragesTolist();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductDto product)
        {
            if (ModelState.IsValid)
            {

             var product1=   await _product.Create(product);

                if (product1 == null)
                {
                    TempData["AlertMessage"] = "can NOT add with this size unit (size unit is larger than Storage)";



                    return View();
                }


                return RedirectToAction("Index");


            }
            else
            {
                return View(product);
            }
        }

     

        // GET: Products/Edit?id=2
        public async Task<IActionResult> Edit(int id)
        {

            var Getproduct = await _product.GetProduct(id);


            if (Getproduct == null)
            {
                return NotFound();
            }

            return View(Getproduct);
        }

        // POST: Products/Edit?id=5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (ModelState.IsValid)
            {

                await _product.UpdateProduct(id, product);

                return RedirectToAction("Index");

            }
            else
            {

                return View(product);
            }
        }

        //Delete: products/DeleteProduct?id=1
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _product.DeleteProduct(id);


            return RedirectToAction("Index");
        }


        // GET: Products/GetByBarCode?barcode=
        public async Task<IActionResult> GetByBarCode(string barcode)
        {
            var product = await _product.GetByBarCode(barcode);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        // GET: products/SortByWeight?falg=ture
        public async Task<IActionResult> SortByWeight(bool flag)
        {
            var products = await _product.SortByWeight(flag);

            return View(products);
        }

        // GET: products/SortByDate?falg=ture
        public async Task<IActionResult> SortByDate(bool flag)
        {
            var products = await _product.SortByDate(flag);

            return View(products);
        }

        // GET: products/SortByExpirationDate?falg=ture
        public async Task<IActionResult> SortByExpirationDate(bool flag)
        {
            var products = await _product.SortByExpirationDate(flag);

            return View(products);
        }

        // GET:  products/SortBySize?falg=ture
        public async Task<IActionResult> SortBySize(bool flag)
        {
            var products = await _product.SortBySize(flag);

            return View(products);
        }

        //products/FilterByProductType?input=food
        public async Task<IActionResult> FilterByProductType(string input)
        {
            var products = await _product.FilterByProductType(input);

            return View(products);
        }

        // GET: products/FilterByStorageType?input=on shelves
        public async Task<IActionResult> FilterByStorageType(string input)
        {

            var products = await _product.FilterByStorageType(input);

            return View(products);
        }

        // GET: products/Packing?id=2&newWeight=100&newSize=2 
        public async Task<IActionResult> Packing(int id, int newWeight, int newSize)
        {

            var products = await _product.Packing(id, newWeight, newSize);

            return View(products);
        }
    }
}
