using Warehouse_MS.Models.DTO;
using Warehouse_MS.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse_MS.Data;
using Warehouse_MS.Models;
using System;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Warehouse_MS.Models.Services
{
    public class TransactionService : ITransaction
    {
        private readonly WarehouseDBContext _context;
        private readonly SignInManager<ApplicationUser> _signInMngr;

        public TransactionService(WarehouseDBContext context, SignInManager<ApplicationUser> SignInMngr)
        {
            _context = context;
            _signInMngr = SignInMngr;
        }
        // method to create new Transaction

        public async Task<TransactionDto> Create(TransactionDto transactionDto)
        {

            Transaction transaction = new Transaction()
            {
                ProductId = transactionDto.ProductId,
                Type = transactionDto.Type,
                newLocation = transactionDto.NewLocation,
                OldLocation = transactionDto.OldLocation,
                UpdateDate = DateTime.Now,
                UpdatedBy = transactionDto.UpdatedBy
            };
            _context.Entry(transaction).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return transactionDto;
        }

        // method to get specific Transaction by id


        public async Task<Transaction> GetTransaction(int id)
        {
            return await _context.Transaction.FirstOrDefaultAsync(z => z.Id == id);
        }
        // method to get all Transaction

        public async Task<List<Transaction>> GetTransactions()
        {
            return await _context.Transaction.ToListAsync();
        }
        // method to update Transaction
        public async Task<Transaction> UpdateTransaction(int id, Transaction transaction)
        {
            _context.Entry(transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();

         
            return transaction;
        }
        //method to delete Transaction
        public async Task Delete(int id)
        {
            Transaction transaction = await _context.Transaction.FindAsync(id);

            //if (transaction == null)
            //{
            //    return ;
            //}

            _context.Entry(transaction).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }
        

    }
}
