using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Warehouse_MS.Auth.Models;
using Warehouse_MS.Models;
using Warehouse_MS.Models.DTO;
using Warehouse_MS.Models.Interfaces;

namespace Warehouse_MS.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly IWarehouse _warehouse;
        private readonly UserManager<ApplicationUser> _userManager;

        public WarehouseController(IWarehouse Warehouse, UserManager<ApplicationUser> userManager)
        {
            this._warehouse = Warehouse;
            this._userManager = userManager;
        }

        // GET: api/Warehouse
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IEnumerable<WarehouseDto> Warehouses = await _warehouse.GetWarehouses();
            return View(Warehouses);
        }

        // GET: api/Warehouse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WarehouseDto>> Details(int id)
        {
            WarehouseDto warehouse = await _warehouse.GetWarehouse(id);

            return View(warehouse);
        }

        // PUT: api/Warehouse/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Warehouse>> Edit(int id)
        {
            WarehouseDto warehouseDto = await _warehouse.GetWarehouse(id);

            Warehouse warehouse = new Warehouse
            {
                Id = warehouseDto.Id,
                Name = warehouseDto.Name,
                Description = warehouseDto.Description,
                SizeInUnit = warehouseDto.SizeInUnit,
                Location = warehouseDto.Location


            };

            return View(warehouse);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                await _warehouse.UpdateWarehouse(warehouse.Id, warehouse);

                return RedirectToAction("Index");
            }

            return View(warehouse);
        }
        // POST: api/Warehouse
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
                    Location = warehouse.Location

                };

                await _warehouse.Create(newwarehouse);
                return RedirectToAction("Index");
            }

            return View(warehouse);
        }

        // DELETE: api/Warehouse/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Warehouse = await _warehouse.GetWarehouse(id);
            if (Warehouse == null)
            {
                return View("Error");
            }
            await _warehouse.Delete(id);
            return Redirect("./");

        }
    }
}