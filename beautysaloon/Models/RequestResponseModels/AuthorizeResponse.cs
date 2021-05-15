using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautysaloon.Models.RequestResponseModels
{
    class AuthorizeResponse
    {
        public User CurrentUser { get; set; }
        public bool Found { get; set;}
        public string Status { get; set; }
    }
}
