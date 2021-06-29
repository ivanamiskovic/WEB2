using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2_Backend.Model
{
    public class SafetyDocument : Entity
    {
        public DocumentType DocumentType;
        public DocumentStatus DocumentStatus;
        public string Details;
        public string Notes;
        public string PhoneNumber;
        public DateTime CreateDateAndTime;
        public User Operater { get; set; }
    }
}
