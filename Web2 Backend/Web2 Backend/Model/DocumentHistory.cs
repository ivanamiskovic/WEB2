using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2_Backend.Model
{
    public class DocumentHistory : Entity
    {
        public User User { get; set; }
        public  DocumentStatus DocumentStatus { get; set; }
        public DateTime DateTime { get; set; }
        public WorkRequest WorkRequest { get; set; }
    }
}
