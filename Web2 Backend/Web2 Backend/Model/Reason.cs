using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2_Backend.Model
{
    public enum Reason
    {
        NoEletricity = 1, BreakdownTrue = 2, LightFlickering = 3, ElectricityReturn = 4,
        PartialElecticity = 5, VoltageProblems = 6
    }
}
