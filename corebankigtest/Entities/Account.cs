using System.Collections.Generic;

namespace corebankigtest.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public string? AccountNumber { get; set; }
        public DateTime OpeningDate { get; set; }

        public string? AccountType { get; set; }
        public string? Address {  get; set; }


        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
