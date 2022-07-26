using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse_MS.Models;
using Warehouse_MS.Models.Interfaces;

namespace Warehouse_MS.Controllers
{
    public class StorageTypeController : Controller
    {
        private readonly IStorageType _storageType;

        public StorageTypeController(IStorageType storageType)
        {
            this._storageType = storageType;
        }

        // GET: api/StorageTypes
        
        public async Task<IActionResult> Index()
        {
            IEnumerable<StorageType> storageTypes = await _storageType.GetStorageTypes();
            return View(storageTypes);
        }

        // GET: api/StorageType/5

        public async Task<IActionResult> Details(int id)
        {
            StorageType storageType = await _storageType.GetStorageType(id);
            if (storageType == null)
            {
                return View("Error");
            }
            return View(storageType);
        }

        public async Task<IActionResult> goEditView(int id)
        {
            StorageType storageType = await _storageType.GetStorageType(id);
            if (storageType == null)
            {
                return View("Error");
            }
            ViewBag.flagReqType = "Edit";
            return View("Edit", storageType);
        }
        public async Task<IActionResult> goAddView()
        {
            ViewBag.flagReqType = "add";


            return View("Add");
        }


        // PUT: api/StorageType/5
        //[HttpPut("{id}")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, StorageType storageType)
        {
            if (id != storageType.Id)
            {
                return View("Error");
            }
            StorageType newStorageType = await _storageType.UpdateStorageType(id, storageType);

            if (ModelState.IsValid)
            {
               
                TempData["AlertMessage"] = $"The {newStorageType.Name}  Updated successfully :)";

                return RedirectToAction("Index", "StorageType");
            }
            else
            {

                return View("Edit");
            }
        }

        // POST: api/StorageType
        [HttpPost]
        public async Task<ActionResult<StorageType>> Add(StorageType storageType)
        {
            StorageType newStorageType = await _storageType.Create(storageType);

            if (ModelState.IsValid)
            {

                TempData["AlertMessage"] = $"The {newStorageType.Name}  Added successfully :)";

                return RedirectToAction("Index", "StorageType");
            }
            else
            {

                return View("Add");
            }

        }

        // DELETE: api/StorageType/5
    
        public async Task<IActionResult> Delete(int id)
        {
            var storgeType = await _storageType.GetStorageType(id);
            if (storgeType == null)
            {
                return View("Error");
            }

            await _storageType.Delete(id);
            TempData["AlertMessage"] = "Delete The StorageType done successfully :)";

            return RedirectToAction("Index", "StorageType");

        }

    }
}
