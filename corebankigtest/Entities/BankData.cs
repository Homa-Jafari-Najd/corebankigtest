using System.Collections.Generic;
using System;
namespace corebankigtest.Entities
{
    public static class BankData
    {
        public static List<Customer> Customers { get; private set; } = new List<Customer>();
        static BankData()
        {
            SeedData();
        }
        private static void SeedData()
        {
            var c1 = new Customer
            {
                CustomerId = 1,
                CustomerFirstName = "Ali",
                CustomerLastName = "Ahmadi",
                CustomerNationalCode = "1234567890"
            };
            var c2 = new Customer
            {
                CustomerId = 2,
                CustomerFirstName = "Sara",
                CustomerLastName = "Kamali",
                CustomerNationalCode = "12345675432"
            };

            var c3 = new Customer
            {
                CustomerId = 3,
                CustomerFirstName = "Mina",
                CustomerLastName = "Moradi",
                CustomerNationalCode = "97867564342"

            };

            var a1 = new Account
            {
                AccountId = 1,
                AccountNumber = "ACC1001",
                OpeningDate = DateTime.Now.AddMonths(-2),
                AccountType = "Current",
                Address = "Montreal",
                CustomerId = c1.CustomerId,
                Customer = c1
            };
            var a2 = new Account
            {
                AccountId = 2,
                AccountNumber = "ACC10012",
                OpeningDate = DateTime.Now.AddMonths(-1),
                AccountType = "Saving",
                Address = "Toronto",
                CustomerId = c1.CustomerId,
                Customer = c1
            };

            var a3 = new Account
            {
                AccountId = 3,
                AccountNumber = "ACC2001",
                OpeningDate = DateTime.Now.AddDays(-10),
                AccountType = "Current",
                Address = "Calgery",
                CustomerId = c2.CustomerId,
                Customer = c2

            };
            c1.Accounts.Add(a1);
            c1.Accounts.Add(a2);
            c2.Accounts.Add(a3);
            Customers = new List<Customer> { c1, c2, c3 };

        }
    }
}