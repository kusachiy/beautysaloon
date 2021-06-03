using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautysaloon.Models
{
   public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; internal set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
