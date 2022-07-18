using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse_MS.Models;
using Warehouse_MS.Models.DTO;
using Warehouse_MS.Models.Interfaces;

namespace Warehouse_MS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouse _warehouse;

        public WarehouseController(IWarehouse warehouse)
        {
            _warehouse = warehouse;
        }

        // GET: api/Warehouse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarehouseDto>>> GetWarehouses()
        {
            var warehouses = await _warehouse.GetWarehouses();
            return Ok(warehouses);
        }

        // GET: api/Warehouse/id
        [HttpGet("{id}")]
        public async Task<ActionResult<WarehouseDto>> GetWarehouse(int id)
        {
            var warehouse = await _warehouse.GetWarehouse(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            return Ok(warehouse);
        }

        // PUT: api/Warehouse/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarehouse(int id, Warehouse warehouse)
        {

            if (id != warehouse.Id)
            {
                return BadRequest();
            }
            var modifiedWarehouse = await _warehouse.UpdateWarehouse(id, warehouse);
            return Ok(modifiedWarehouse);
        }

        // POST: api/Warehouse
        [HttpPost]
        public async Task<ActionResult<WarehouseDto>> PostCategory(Warehouse warehouse)
        {
            WarehouseDto newWarehouse = await _warehouse.Create(warehouse);
            return Ok(newWarehouse);
        }

        // DELETE: api/Warehouse/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouse(int id)
        {
            await _warehouse.Delete(id);
            return NoContent();
        }
    }
}
