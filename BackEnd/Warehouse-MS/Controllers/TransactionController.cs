using Warehouse_MS.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse_MS.Models;
using Warehouse_MS.Models.DTO;

namespace Warehouse_MS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly ITransaction _transaction;

        public TransactionController(ITransaction transaction)
        {
            this._transaction = transaction;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GeTransactions()
        {
            var transactions = await _transaction.GetTransactions();
            return Ok(transactions);
        }

        // GET: api/Transaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            Transaction transaction = await _transaction.GetTransaction(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        // PUT: api/Transaction/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(int id, Transaction transaction)
        {

            if (id != transaction.Id)
            {
                return BadRequest();
            }
            Transaction newTransaction = await _transaction.UpdateTransaction(id, transaction);

            return Ok(newTransaction);
        }

        // POST: api/Transaction
        [HttpPost]
        public async Task<ActionResult<TransactionDto>> PostTransaction(TransactionDto transactionDto)
        {
            TransactionDto newTransaction = await _transaction.Create(transactionDto);
            return Ok(newTransaction);

        }

        // DELETE: api/Transaction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await _transaction.GetTransaction(id);
            if (transaction == null)
            {
                return NotFound();
            }
            await _transaction.Delete(id);
            return NoContent();

        }

    }
}
