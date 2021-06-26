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

        public override PageResponse<WorkingPlan> GetAll(int page, int perPage, string search)
        {
            string term = search.ToLower();

            var query = Web2Context.WorkingPlans.Where(x => x.Street.ToLower().Contains(term)
            || x.Point.ToLower().Contains(term) ||
            x.Notes.ToLower().Contains(term) || x.Company.ToLower().Contains(term) ||
            x.Number.ToLower().Contains(term));

            return new PageResponse<WorkingPlan>(query.Skip(page * perPage).Take(perPage).ToList(), query.Count());
        }

    }
}
