using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Core;
using Web2_Backend.Model;

namespace Web2_Backend.Repository
{
    public class SafetyDocumentRepository : Repository<SafetyDocument>, ISafetyDocumentRepository
    {
        public SafetyDocumentRepository(Web2Context context) : base(context) { }
        public override IEnumerable<SafetyDocument> GetAll()
        {
            return Web2Context.SafetyDocuments.Where(x => x.Deleted == false).ToList();
        }

        public PageResponse<SafetyDocument> GetAll(int page, int perPage, string search, User user, string sort)
        {
            string term = search == null ? string.Empty : search.ToLower();

            var query = Web2Context.SafetyDocuments.Where(x => (x.Details.ToLower().Contains(term)
            || x.Notes.ToLower().Contains(term) || x.PhoneNumber.ToLower().Contains(term)) && x.Operater.Id == user.Id);

            if (sort == "DESC")
            {
                query = query.OrderByDescending(x => x.Id);
            }
            else
            {
                query = query.OrderBy(x => x.Id);
            }

            return new PageResponse<SafetyDocument>(query.Skip(page * perPage).Take(perPage).ToList(), query.Count());
        }
    }
}
