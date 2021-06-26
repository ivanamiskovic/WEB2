using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Core;
using Web2_Backend.Model;

namespace Web2_Backend.Repository
{
    public class CrewRepository : Repository<Crew>, ICrewRepository
    {
        public CrewRepository(Web2Context context) : base(context) { }

        public override IEnumerable<Crew> GetAll()
        {
            return Web2Context.Crews.Where(x => x.Deleted == false).ToList();
        }
        public override PageResponse<Crew> GetAll(int page, int perPage, string search)
        {
            string term = search == null ? string.Empty : search.ToLower();

            var query = Web2Context.Crews.Where(x => x.Name.ToLower().Contains(term));

            return new PageResponse<Crew>(query.Skip(page * perPage).Take(perPage).ToList(), query.Count());
        }
    }
}
