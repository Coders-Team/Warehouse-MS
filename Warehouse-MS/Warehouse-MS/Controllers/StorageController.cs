using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse_MS.Models;
using Warehouse_MS.Models.DTO;
using Warehouse_MS.Models.Interfaces;

namespace Warehouse_MS.Controllers
{
    [Authorize]
    public class StorageController : Controller
    {
        private readonly IStorage _storage;

        public StorageController(IStorage storage)
        {
            _storage = storage;
        }

        public async Task<IActionResult> Index()
        {
            List<StorageDto> storages = await _storage.GetStorages();
            return View(storages);
        }
        public async Task<ActionResult<StorageDto>> Details(int id)
        {
            StorageDto storage = await _storage.GetStorage(id);

            return View(storage);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Storage storage)
        {
            await _storage.Create(storage);

            return Redirect("/storage/index");
        }
        public async Task<ActionResult<Storage>> Edit(int id)
        {
            StorageDto storageDto = await _storage.GetStorage(id);

            Storage storage = new Storage
            {
                Id = storageDto.Id,
                Name = storageDto.Name,
                SizeInUnit = storageDto.SizeInUnit,
                LocationInWarehouse = storageDto.LocationInWarehouse,
                Description = storageDto.Description,
                WarehouseId = storageDto.WarehouseId,
                StorageTypeId = storageDto.StorageTypeId
            };

            return View(storage);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id ,Storage storage)
        {
            await _storage.UpdateStorage(id , storage);

            return Redirect("/storage/index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _storage.Delete(id);
            return Redirect("/storage/index");
        }
    }
}