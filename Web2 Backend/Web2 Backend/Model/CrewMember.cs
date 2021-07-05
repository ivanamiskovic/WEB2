using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2_Backend.Model
{
    public class CrewMember : Entity
    {
        public User User { get; set; }

        public Crew Crew { get; set; }
    }
}
