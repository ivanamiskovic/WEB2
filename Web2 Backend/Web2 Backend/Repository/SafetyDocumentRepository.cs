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

        public override PageResponse<SafetyDocument> GetAll(int page, int perPage, string search)
        {
            string term = search.ToLower();

            var query = Web2Context.SafetyDocuments.Where(x => x.Details.ToLower().Contains(term)
            || x.Notes.ToLower().Contains(term) || x.PhoneNumber.ToLower().Contains(term));

            return new PageResponse<SafetyDocument>(query.Skip(page * perPage).Take(perPage).ToList(), query.Count());
        }
    }
}
