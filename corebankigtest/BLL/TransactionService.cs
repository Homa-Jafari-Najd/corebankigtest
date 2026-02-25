using corebankigtest.Entities;
using corebankigtest.DAL.Abstractions;

namespace corebankigtest.BLL
{
    public class TransactionService
    {
        private readonly ITransactionRepository _repo;
        public TransactionService(ITransactionRepository repo)
        {
            _repo = repo;
        }

        public List<Transaction> GetTransactions(int accountId)
        
            =>_repo.GetByAccountId(accountId);

        public void DeleteTransaction(int transactionId)

        => _repo.DeleteTransactionAndRevertBalance(transactionId);
        public void InsertTransaction(int accountId,decimal amount,string type)
        
           => _repo.Insert(accountId,amount,type);
        
    }
}