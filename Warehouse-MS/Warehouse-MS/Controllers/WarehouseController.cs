using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Warehouse_MS.Models;
using Warehouse_MS.Models.DTO;
using Warehouse_MS.Models.Interfaces;

namespace Warehouse_MS.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly IWarehouse _warehouse;

        public WarehouseController(IWarehouse Warehouse)
        {
            this._warehouse = Warehouse;
        }


        public async Task<ActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<WarehouseDto> Warehouses = await _warehouse.GetUserWarehouse(userId);
            return View(Warehouses);
        }

        public async Task<ActionResult<WarehouseDto>> Details(int id)
        {
            WarehouseDto warehouse = await _warehouse.GetWarehouse(id);

            return View(warehouse);
        }

        public async Task<ActionResult<Warehouse>> Edit(int id)
        {
            WarehouseDto warehouseDto = await _warehouse.GetWarehouse(id);
                Warehouse warehouse = new Warehouse
                {
                    Id = warehouseDto.Id,
                    Name = warehouseDto.Name,
                    Description = warehouseDto.Description,
                    SizeInUnit = warehouseDto.SizeInUnit,
                    Location = warehouseDto.Location,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };
            return View(warehouse);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, Warehouse warehouse)
        {
            await _warehouse.UpdateWarehouse(id, warehouse);

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Create(WarehouseDto warehouse)
        {

            if (ModelState.IsValid)
            {
                Warehouse newwarehouse = new Warehouse
                {
                    Id = warehouse.Id,
                    Name = warehouse.Name,
                    Description = warehouse.Description,
                    SizeInUnit = warehouse.SizeInUnit,
                    Location = warehouse.Location,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)

                };

                await _warehouse.Create(newwarehouse);
                return RedirectToAction("Index");
            }

            return View(warehouse);
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _warehouse.Delete(id);
            return RedirectToAction("Index");
        }

    }
}