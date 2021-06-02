using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautysaloon.Models
{
    public class ServiceProvision
    {
        public int Id { get; set; }
        public int ClientId { get; set; }

        public Client Client { get; set; }
        public int ServiceId { get; set; }

        public Service Service { get; set; }
        public int MasterId { get; set; }
        public User Master { get; set; }
        public DateTime Dt { get; set; }

    }
}
