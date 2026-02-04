using System;
using System.Data;
using System.Text.RegularExpressions;
using corebankigtest.DAL;

namespace corebankigtest.BLL
{
    public class CustomerService
    {
        private readonly CustomerRepository _repo;

        public CustomerService()
        {
            _repo = new CustomerRepository();
        }

        public DataTable SearchCustomerByNationalCode(string nationalCode)
        {
            // 1) Null / Empty
            if (string.IsNullOrWhiteSpace(nationalCode))
                throw new ArgumentException("National Code is required.");

            // 2) فقط عدد
            nationalCode = nationalCode.Trim();
            if (!Regex.IsMatch(nationalCode, @"^\d+$"))
                throw new ArgumentException("National Code must be numeric.");

            // 3) اگر کد ملی ایران می‌خوای: 10 رقم
            if (nationalCode.Length != 10)
                throw new ArgumentException("National Code must be 10 digits.");

            // Call DAL
            return _repo.SearchByNationalCode(nationalCode);
        }
    }
}