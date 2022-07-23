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
        [HttpGet]
        public async Task<IActionResult> Index()
        {


            IEnumerable<StorageType> storageTypes = await _storageType.GetStorageTypes();
            return View(storageTypes);
        }

        // GET: api/StorageType/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            StorageType storageType = await _storageType.GetStorageType(id);
            if (storageType == null)
            {
                return View("Error");
            }
            return View(storageType);
        }

        // PUT: api/StorageType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, StorageType storageType)
        {
            if (id != storageType.Id)
            {
                return View("Error");
            }
            StorageType newStorageType = await _storageType.UpdateStorageType(id, storageType);

            return View(newStorageType);
        }

        // POST: api/StorageType
        [HttpPost]
        public async Task<ActionResult<StorageType>> Add(StorageType storageType)
        {
            StorageType newStorageType = await _storageType.Create(storageType);
            return View(newStorageType);

        }

        // DELETE: api/StorageType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var storgeType = await _storageType.GetStorageType(id);
            if (storgeType == null)
            {
                return View("Error");
            }

            await _storageType.Delete(id);
            return Redirect("/");

        }

    }
}
