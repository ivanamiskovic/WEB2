using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2_Backend.Model
{
    public class Calls : Entity
    {
        public Reason Reason { get; set; }
        public string Comment { get; set; }
        public string BreakdownName { get; set; }
        public int BreakdownPriority { get; set; }
        
    }
}
