using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautysaloon.Models
{
    public class UserTime
    {
        public TimeSpan Value { get; set; }

        public UserTime(int hour, bool withHalf)
        {
            Value = new TimeSpan(hour, withHalf ? 30 : 0, 0);
        }
        public override string ToString()
        {
            return $"{Value.Hours}:{(Value.Minutes>0?"30":"00")}";
        }
    }
}
