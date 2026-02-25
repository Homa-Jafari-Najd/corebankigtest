using System;
using System.Collections.Generic;
using System.Text;
using corebankigtest.DAL.Factories;
using corebankigtest.Entities;
using corebankigtest.BLL;


namespace corebankigtest.DAL.Abstractions
{
    
public interface ITransactionRepository
    {
        List<Transaction> GetByAccountId(int accountId);
        void DeleteTransactionAndRevertBalance(int transactionId);
        void Insert(int accountId, decimal amount, string type);
    }
}

