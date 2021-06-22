using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2_Backend.Model
{
    public class Cosumer: Entity

    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int Priority { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }      
        public string Type { get; set; }
    }
}