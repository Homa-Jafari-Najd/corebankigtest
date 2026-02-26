using System;
using System.Collections.Generic;
using System.Text;
using CoreBanking.Entities;

namespace CoreBanking.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string? AccountNumber { get; set; }
        public DateTime CreateDate { get; set; }

        public string? AccountType { get; set; }
        public string? Address {  get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public string? FullName { get; set; }

        public Decimal? Balance { get; set; }
    }
}
