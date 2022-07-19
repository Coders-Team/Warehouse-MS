using Warehouse_MS.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse_MS.Models;

namespace Warehouse_MS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageTypeController : Controller
    {
        private readonly IStorageType _storageType;

        public StorageTypeController(IStorageType storageType)
        {
            this._storageType = storageType;
        }

        // GET: api/StorageTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StorageType>>> GeStorageTypes()
        {
            var storageTypes = await _storageType.GetStorageTypes();
            return Ok(storageTypes);
        }

        // GET: api/StorageType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StorageType>> GetStorageType(int id)
        {
            StorageType storageType = await _storageType.GetStorageType(id);
            return Ok(storageType);
        }

        // PUT: api/StorageType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStorageType(int id, StorageType storageType)
        {
            if (id != storageType.Id)
            {
                return BadRequest();
            }
            StorageType newStorageType = await _storageType.UpdateStorageType(id, storageType);

            return Ok(newStorageType);
        }

        // POST: api/StorageType
        [HttpPost]
        public async Task<ActionResult<StorageType>> PostStorageType(StorageType storageType)
        {
            StorageType newStorageType = await _storageType.Create(storageType);
            return Ok(newStorageType);

        }

        // DELETE: api/StorageType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorageType(int id)
        {
            await _storageType.Delete(id);
            return NoContent();

        }


    }
}
