using System;
using System.Collections.Generic;
using System.Text;
using CoreBanking.Entities;

namespace CoreBanking.Entities
{


    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Role { get; set; } = "";
        public bool IsActive { get; set; }

    }

}