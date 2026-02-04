using System;
using System.Data;
using corebankigtest.DAL;
using corebankigtest.BLL;

namespace corebankigtest.BLL
{
    public class AccountService
    {
        private readonly AccountRepository _repo;

        public AccountService()
        {
            _repo = new AccountRepository();
        }

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
    }
}