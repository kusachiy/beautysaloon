﻿using beautysaloon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautysaloon
{
   public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string HashPassword { get; set; }
        public int RoleID { get; set; }

        public Role Role { get;set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
