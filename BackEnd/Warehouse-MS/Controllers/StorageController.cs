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
    public class StorageController : ControllerBase
    {
        private readonly IStorage _storage;

        public StorageController(IStorage storage)
        {
            _storage = storage;
        }

        // GET: api/Storage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StorageDto>>> GetStorages()
        {
            var storages = await _storage.GetStorages();
            return Ok(storages);
        }

        // GET: api/Storage/id
        [HttpGet("{id}")]
        public async Task<ActionResult<StorageDto>> GetStorages(int id)
        {
            var storage = await _storage.GetStorage(id);
            if (storage == null)
            {
                return NotFound();
            }
            return Ok(storage);
        }

        // PUT: api/Storage/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStorage(int id, Storage storage)
        {

            if (id != storage.Id)
            {
                return BadRequest();
            }
            var modifiedStorage = await _storage.UpdateStorage(id, storage);
            return Ok(modifiedStorage);
        }

        // POST: api/Storage
        [HttpPost]
        public async Task<ActionResult<WarehouseDto>> PostCategory(Storage storage)
        {
            StorageDto newStorage = await _storage.Create(storage);
            return Ok(newStorage);
        }

        // DELETE: api/Storage/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorage(int id)
        {
            await _storage.Delete(id);
            return NoContent();
        }
    }
}
