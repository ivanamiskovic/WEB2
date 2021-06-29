using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;

namespace Web2_Backend.Core
{
    public interface ISwitchingPlanRepository : IRepository<SwitchingPlan>
    {
        PageResponse<SwitchingPlan> GetAll(int page, int perPage, string search, User user);
    }
}
