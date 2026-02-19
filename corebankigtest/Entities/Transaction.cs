using System;
using System.Collections.Generic;
using System.Text;

namespace corebankigtest.Entities
{
    public class Transaction
    {
        public int TransactionId {  get; set; }
        public int AccountId {  get; set; }
        public decimal Amount {  get; set; }
        public string Type {  get; set; }

        public DateTime ? TransactionDate {  get; set; }
    }
}
