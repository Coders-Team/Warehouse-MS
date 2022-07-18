using FastMarket.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse_MS.Models;

namespace FastMarket.Models.Interfaces
{
    public interface ITransaction
    {

        // method to get all Transaction
        Task<List<Transaction>> GetTransactions();
        // method to get specific Transaction by id

        Task<Transaction> GetTransaction(int id);

        // method to create new Transaction

        Task<TransactionDto> Create(TransactionDto transactionDto);
        // method to update a Transaction

        Task<Transaction> UpdateTransaction(int id, Transaction transaction);
        // method to delete a Transaction

        Task Delete(int id);



    }
}
