using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Core;
using Web2_Backend.Model;

namespace Web2_Backend.Repository
{
    public class SolutionRepository : Repository<Solution>, ISolutionRepository
    {
        public SolutionRepository(Web2Context context) : base(context) { }

        public override IEnumerable<Solution> GetAll()
        {
            return Web2Context.Solutions.Where(x => x.Deleted == false).ToList();
        }

        public PageResponse<Solution> GetAll(int page, int perPage, string search)
        {
            string term = search == null ? string.Empty : search.ToLower();

            var query = Web2Context.Solutions.Where(x => x.Cause.ToLower().Contains(term)
            || x.SubCase.ToLower().Contains(term) || x.Material.ToLower().Contains(term));

            return new PageResponse<Solution>(query.Skip(page * perPage).Take(perPage).ToList(), query.Count());
        }
    }
}
