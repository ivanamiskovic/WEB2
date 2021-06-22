using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2_Backend.Model
{
    public class Incident : Entity
    {
        public IncidentType IncidentType { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public bool Confirmed { get; set; }

        public int Status { get; set; }

        public DateTime ETA { get; set; }

        public DateTime ATA { get; set; }

        public DateTime IncidentDateAndTime { get; set; }

        public DateTime ETR { get; set; }

        public int AffectedCustomers { get; set; }

        public int Calls { get; set; }

        public double VoltegeLevel { get; set; }

        public DateTime EstimatedWorkTime { get; set; }

        public User Operater { get; set; }
    }
}
