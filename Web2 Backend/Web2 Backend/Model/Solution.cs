using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2_Backend.Model
{
    public class Solution : Entity
    {
        public string Cause { get; set; }

        public string SubCase { get; set; }

        public ConstructionType ConstructionType { get; set; }

        public string Material { get; set; }
    }
}
