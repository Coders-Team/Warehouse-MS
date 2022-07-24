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
    public class TransactionController : Controller
    {
        private readonly ITransaction _transaction;
        private readonly UserManager<ApplicationUser> _userManager;

        public TransactionController(ITransaction transaction, UserManager<ApplicationUser> userManager)
        {
            this._transaction = transaction;
            this._userManager = userManager;
        }

        // GET: api/Transaction
        [HttpGet]
        public async Task<ActionResult> Index()
        {
           IEnumerable<Transaction> transactions = await _transaction.GetTransactions();
            return View(transactions);
        }

        // GET: api/Transaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Details(int id)
        {
            Transaction transaction = await _transaction.GetTransaction(id);
            if (transaction == null)
            {
                return View("Error");
            }
            return View(transaction);
        }

        // PUT: api/Transaction/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Transaction transaction)
        {

            if (id != transaction.Id)
            {
                return View("Error");
            }
            Transaction newTransaction = await _transaction.UpdateTransaction(id, transaction);

            return View(newTransaction);
        }

        // POST: api/Transaction
        [HttpPost]
        public async Task<ActionResult> Add(TransactionDto transactionDto)
        {
            transactionDto.UpdatedBy = User.FindFirstValue(ClaimTypes.NameIdentifier);

            TransactionDto newTransaction = await _transaction.Create(transactionDto);
            return View(newTransaction);

        }

        // DELETE: api/Transaction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var transaction = await _transaction.GetTransaction(id);
            if (transaction == null)
            {
                return View("Error");
            }
            await _transaction.Delete(id);
            return Redirect("./");

        }
    }
}
