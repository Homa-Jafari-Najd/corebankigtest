using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using corebankigtest.Entities;

namespace corebankigtest.DAL.Abstractions
{

    public interface IAccountRepository
    {
        List<AccountComboItem> GetAccountsForCombo();
        DataTable GetAccountsPaged(int pageNumber, int pageSize, string search);
        int GetTotalAccounts(string search);
        void UpdateBalance(int Id, decimal amount, string type);
        decimal GetBalance(int accountId);
        User? GetUserByUsernamePassword(string username, string password);
    }
}
