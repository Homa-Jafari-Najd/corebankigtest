using System;
using System.Collections.Generic;
using System.Text;
using CoreBanking.Entities;




namespace CoreBanking.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NationalCode { get; set; }
        public bool Gender { get; set; }

        public string? UserName { get; set; }
        public string? Password { get; set; }

        public Employee()
        {

        }
    }
}