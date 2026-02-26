using System;
using System.Collections.Generic;
using System.Data;
using CoreBanking.Entities;

namespace CoreBanking.DataAccess.Abstractions
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
