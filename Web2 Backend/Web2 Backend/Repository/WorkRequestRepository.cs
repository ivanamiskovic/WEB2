using System;
using System.Collections.Generic;
using System.Linq;
using Web2_Backend.Core;
using Web2_Backend.Model;

namespace Web2_Backend.Repository
{
    public class WorkRequestRepository : Repository<WorkRequest>, IWorkRequestRepository
    {
        public WorkRequestRepository(Web2Context context) : base(context) { }

        public override IEnumerable<WorkRequest> GetAll()
        {
            return Web2Context.WorkRequests.Where(x => x.Deleted == false).ToList();
        }

        public PageResponse<WorkRequest> GetAll(int page, int perPage, string search, User user, string sort)
        {
            string term = search == null ? string.Empty : search.ToLower();

            var query = Web2Context.WorkRequests.Where(x => (x.Type.ToLower().Contains(term)
            || x.Status.ToLower().Contains(term) || x.Address.ToLower().Contains(term) ||
            x.Cause.ToLower().Contains(term) || x.Note.ToLower().Contains(term) ||
            x.Company.ToLower().Contains(term) || x.PhoneNumber.ToLower().Contains(term)) && x.Deleted == false && x.Operater.Id == user.Id);

            if (sort == "DESC")
            {
                query = query.OrderByDescending(x => x.Id);
            }
            else
            {
                query = query.OrderBy(x => x.Id);
            }

            return new PageResponse<WorkRequest>(query.Skip(page * perPage).Take(perPage).ToList(), query.Count());
        }
    }
}