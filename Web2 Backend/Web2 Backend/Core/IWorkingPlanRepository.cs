using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;

namespace Web2_Backend.Core
{
    public  interface IWorkingPlanRepository: IRepository<WorkingPlan>
    {
        PageResponse<WorkingPlan> GetAll(int page, int perPage, string search, User user);
    }
}
