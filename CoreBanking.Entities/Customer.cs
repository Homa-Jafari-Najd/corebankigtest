using System;
using System.Collections.Generic;
using System.Text;
using CoreBanking.Entities;





namespace CoreBanking.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? NationalCode { get; set; }

    }
}
