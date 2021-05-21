using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Core;
using Web2_Backend.Model;

namespace Web2_Backend.Repository
{
    public class WorkingPlanRepository : Repository<WorkingPlan>, IWorkingPlanRepository
    {
        public WorkingPlanRepository(Web2Context context) : base(context) { }
    
    }
}
