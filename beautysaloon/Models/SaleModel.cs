using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautysaloon.Models
{
    class SaleModel
    {
        public int Value { get; set; }
        public override string ToString()
        {
            return $"{Value} %";
        }
    }
}
