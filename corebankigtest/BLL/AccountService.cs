using System;
using System.Data;
using corebankigtest.DAL;
using corebankigtest.BLL;
using System.Collections.Generic;
using corebankigtest.Entities;
using Microsoft.Identity.Client;

namespace corebankigtest.BLL
{
    public class AccountService
    {
        private readonly AccountRepository _repo;
        public AccountService()
        {
            _repo = new AccountRepository();
        }
        public List<AccountComboItem> GetAccountsForCombo()
            => _repo.GetAccountsForCombo();

        public DataTable GetAccountsPaged(int pageNumber, int pageSize, string search)
        {
            search = (search ?? "").Trim();
            return _repo.GetAccountsPaged(pageNumber, pageSize, search);
        }

        public int GetTotalAccounts(string search)
        {
            search = (search ?? "").Trim();
            return _repo.GetTotalAccounts(search);
        }
        public void UpdateBalance(int Id, decimal amount, string type)
        {
            _repo.UpdateBalance(Id, amount, type);
        }
        public void MakeTransaction(int accountId, decimal amount, string type)
        {
            if (amount <= 0)
                throw new Exception("Amount must be greater than zero.");

            decimal currentBalance = _repo.GetBalance(accountId);

            if (type == "Withdraw" && amount > currentBalance)
                throw new Exception("Insufficient balance. You cannot withdraw more than the current balance.");

            _repo.UpdateBalance(accountId, amount, type);
        }
    }
}