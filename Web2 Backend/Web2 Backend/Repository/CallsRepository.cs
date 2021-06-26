using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Core;
using Web2_Backend.Model;

namespace Web2_Backend.Repository
{
    public class CallsRepository : Repository<Calls>, ICallsRepository
    {
        public CallsRepository(Web2Context context) : base(context) { }

        public override IEnumerable<Calls> GetAll()
        {
            return Web2Context.Calls.Where(x => x.Deleted == false).ToList();
        }

        public override PageResponse<Calls> GetAll(int page, int perPage, string search)
        {
            string term = search.ToLower();

            var query = Web2Context.Calls.Where(x => x.BreakdownName.ToLower().Contains(term)
            || x.Comment.ToLower().Contains(term));

            return new PageResponse<Calls>(query.Skip(page * perPage).Take(perPage).ToList(), query.Count());
        }
    }
}
