using System;
using System.Data;
using corebankigtest.DAL;
using corebankigtest.BLL;
using corebankigtest.DAL.Abstractions;
using corebankigtest.Entities;

namespace corebankigtest.BLL
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;
        public AccountService(IDConnectionFactory Factory)
        {
            _accountRepository = new AccountRepository(Factory);
        }
        public List<AccountComboItem> GetAccountsForCombo()
            => _accountRepository.GetAccountsForCombo();

        public DataTable GetAccountsPaged(int pageNumber, int pageSize, string search)
        {
            search = (search ?? "").Trim();
            return _accountRepository.GetAccountsPaged(pageNumber, pageSize, search);
        }

        public int GetTotalAccounts(string search)
        {
            search = (search ?? "").Trim();
            return _accountRepository.GetTotalAccounts(search);
        }
        public void UpdateBalance(int Id, decimal amount, string type)
        {
            _accountRepository.UpdateBalance(Id, amount, type);
        }
        public void MakeTransaction(int accountId, decimal amount, string type)
        {
            if (amount <= 0)
                throw new Exception("Amount must be greater than zero.");

            decimal currentBalance = _accountRepository.GetBalance(accountId);

            if (type == "Withdraw" && amount > currentBalance)
                throw new Exception("Insufficient balance. You cannot withdraw more than the current balance.");

            _accountRepository.UpdateBalance(accountId, amount, type);
        }
        public User? Login(string username, string password)
        {
            return _accountRepository.GetUserByUsernamePassword(username, password) ;
        }

    }
    
}