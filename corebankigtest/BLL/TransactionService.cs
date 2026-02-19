using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using corebankigtest.DAL;
using corebankigtest.Entities;

namespace corebankigtest.BLL
{
    public class TransactionService
    {
        private readonly TransactionRepository _repo = new TransactionRepository();

        public List<Transaction> GetTransactions(int accountId)
        
            =>_repo.GetByAccountId(accountId);

        public void DeleteTransaction(int transactionId)

        => _repo.DeleteTransactionAndRevertBalance(transactionId);
        public void InsertTransaction(int accountId,decimal amount,string type)
        
           => _repo.Insert(accountId,amount,type);
        
    }
}