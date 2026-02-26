using System;
using System.Collections.Generic;
using System.Text;
using CoreBanking.Entities;

namespace CoreBanking.Entities
{
    public static class BankData
    {
        public static List<Customer> Customers { get; private set; } = new List<Customer>();
        //static BankData()
        //{
        //    SeedData();
        //}
        private static void SeedData()
        {
            var c1 = new Customer
            {
                Id = 1,
                FirstName = "Ali",
                LastName = "Ahmadi",
                NationalCode = "1234567890"
            };
            var c2 = new Customer
            {
                Id = 2,
                FirstName = "Sara",
                LastName = "Kamali",
                NationalCode = "12345675432"
            };

            var c3 = new Customer
            {
                Id = 3,
                FirstName = "Mina",
                LastName = "Moradi",
                NationalCode = "97867564342"

            };

            var a1 = new Account
            {
                Id = 1,
                AccountNumber = "ACC1001",
                CreateDate = DateTime.Now.AddMonths(-2),
                AccountType = "Current",
                Address = "Montreal",
                CustomerId = c1.Id,
            };
            var a2 = new Account
            {
                Id = 2,
                AccountNumber = "ACC10012",
                CreateDate = DateTime.Now.AddMonths(-1),
                AccountType = "Saving",
                Address = "Toronto",
                CustomerId = c1.Id,
            };

            var a3 = new Account
            {
                Id = 3,
                AccountNumber = "ACC2001",
                CreateDate = DateTime.Now.AddDays(-10),
                AccountType = "Current",
                Address = "Calgery",
                CustomerId = c2.Id,

            };

        }
    }
}