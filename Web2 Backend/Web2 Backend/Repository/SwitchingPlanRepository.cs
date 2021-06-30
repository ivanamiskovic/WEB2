using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Core;
using Web2_Backend.Model;

namespace Web2_Backend.Repository
{
    public class SwitchingPlanRepository : Repository<SwitchingPlan>, ISwitchingPlanRepository
    {
        public SwitchingPlanRepository(Web2Context context) : base(context) { }

        public override IEnumerable<SwitchingPlan> GetAll()
        {
            return Web2Context.SwitchingPlans.Where(x => x.Deleted == false).ToList();
        }

        public PageResponse<SwitchingPlan> GetAll(int page, int perPage, string search, User user, string sort)
        {
            string term = search == null ? string.Empty : search.ToLower();

            var query = Web2Context.SwitchingPlans.Where(x => (x.Street.ToLower().Contains(term)
            || x.Notes.ToLower().Contains(term) || x.Company.ToLower().Contains(term) || x.Number.ToLower().Contains(term) || x.Point.ToLower().Contains(term) || x.Team.ToLower().Contains(term)) && x.Operater.Id == user.Id);

            if (sort == "DESC")
            {
                query = query.OrderByDescending(x => x.Id);
            }
            else
            {
                query = query.OrderBy(x => x.Id);
            }

            return new PageResponse<SwitchingPlan>(query.Skip(page * perPage).Take(perPage).ToList(), query.Count());
        }




    }
}
