using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautysaloon
{
    public static class UserContext
    {
        static UserContext()
        {

        }
        public static User CurrentUser { get; set; }
            
    }
}
