using System;
using System.Data;
using CoreBanking.Entities;
using CoreBanking.DataAccess.Abstractions;


namespace CoreBanking.DataAccess.Abstractions
{

    public interface ITransactionRepository
    {
        List<Transaction> GetByAccountId(int accountId);
        void DeleteTransactionAndRevertBalance(int transactionId);
        void Insert(int accountId, decimal amount, string type);
    }
}

