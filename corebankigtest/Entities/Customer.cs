using System;
using System.Collections.Generic;



namespace corebankigtest.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }

        public string? CustomerNationalCode { get; set; }

        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
