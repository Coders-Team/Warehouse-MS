using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
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
        private readonly IWarehouse _warehouse;

        public StorageController(IStorage storage,IWarehouse warehouse)
        {
            _storage = storage;
            this._warehouse = warehouse;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<WarehouseDto> warehouseDto = await _storage.GetStorages(userId);
            return View(warehouseDto);
        }
        public async Task<ActionResult<StorageDto>> Details(int id)
        {
            StorageDto storage = await _storage.GetStorage(id);

            return View(storage);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.warehouses = await _warehouse.GetWarehouseTolist();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StorageDto storage)
        {

            var storage1= await _storage.Create(storage);
            if (storage1== null)
            {
                TempData["AlertMessage"] = "can NOT add with this size unit (size unit is larger than warehouse)";



                return View();
            }

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