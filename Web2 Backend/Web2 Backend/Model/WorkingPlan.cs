using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2_Backend.Model
{
    public class WorkingPlan : Entity
    {

        //public string Status { get; set; }
        //public string Incident { get; set; }
        public string Street { get; set; }
        public DateTime StartOfWork { get; set; }
        public DateTime EndOfWork { get; set; }
        public User UserCreate { get; set; }
        public string Point { get; set; }
        public string Notes { get; set; }
        public string Company { get; set; }
        public string Number { get; set; }
        public DateTime CreateDocument { get; set; }
        public WorkingPlanType Type { get; set; }
        public User Operater { get; set; }
        
        //public string Team { get; set; }
    }
}
