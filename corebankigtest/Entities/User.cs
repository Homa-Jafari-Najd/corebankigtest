using System;
using System.Collections.Generic;
using System.Text;

namespace corebankigtest.Entities
{
    
    
        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; } = "";
            public string Role { get; set; } = "";
            public bool IsActive { get; set; }
        }
    }

