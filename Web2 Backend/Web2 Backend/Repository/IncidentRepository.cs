using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Core;
using Web2_Backend.Model;

namespace Web2_Backend.Repository
{
    public class IncidentRepository : Repository<Incident>, IIncidentRepository
    {
        public IncidentRepository(Web2Context context) : base(context) { }

        public override IEnumerable<Incident> GetAll()
        {
            return Web2Context.Incidents.Include(x => x.Operater).Where(x => x.Deleted == false).ToList();
        }

        public override PageResponse<Incident> GetAll(int page, int perPage, string search, string sort)
        {
            string term = search == null ? "" : search.ToLower();

            var query = Web2Context.Incidents.Include(x => x.Operater).Where(x => x.Description.ToLower().Contains(term));

            if (sort == "DESC")
            {
                query = query.OrderByDescending(x => x.Id);
            }
            else
            {
                query = query.OrderBy(x => x.Id);
            }


            return new PageResponse<Incident>(query.Skip(page * perPage).Take(perPage).ToList(), query.Count());
        }

        public PageResponse<Incident> GetAll(int page, int perPage, string search, User user, string sort)
        {
            string term = search == null ? "" : search.ToLower();

            var query = Web2Context.Incidents.Include(x => x.Operater).Where(x => x.Description.ToLower().Contains(term)
            && x.Operater.Id == user.Id);

            if (sort == "DESC")
            {
                query = query.OrderByDescending(x => x.Id);
            }
            else
            {
                query = query.OrderBy(x => x.Id);
            }

            return new PageResponse<Incident>(query.Skip(page * perPage).Take(perPage).ToList(), query.Count());
        }

    }
}
