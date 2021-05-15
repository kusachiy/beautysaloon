using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautysaloon
{
    public static class Extensions
    {
        public static string WithPartipiants(this string input)
        {
            return "N'" + input + "'";
        }
    }
}
