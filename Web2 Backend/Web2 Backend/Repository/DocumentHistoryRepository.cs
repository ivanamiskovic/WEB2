using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Core;
using Web2_Backend.Model;

namespace Web2_Backend.Repository
{
    public class DocumentHistoryRepository : Repository<DocumentHistory>, IDocumentHistoryRepository
    {
        public DocumentHistoryRepository(Web2Context context) : base(context) { }

        public override IEnumerable<DocumentHistory> GetAll()
        {
            return Web2Context.DocumentHistories.Where(x => x.User.Deleted == false).ToList();
        }

        public override PageResponse<DocumentHistory> GetAll(int page, int perPage, string search, string sort)
        {
            string term = search == null ? string.Empty : search.ToLower();


            var query = Web2Context.DocumentHistories.Where(x => (x.User.Username.ToLower().Contains(term)
          || x.User.Email.ToLower().Contains(term) || x.User.Name.ToLower().Contains(term) ||
          x.User.LastName.ToLower().Contains(term) || x.User.Address.ToLower().Contains(term)) ||
           (x.WorkRequest.Type.ToLower().Contains(term)
            || x.WorkRequest.Status.ToLower().Contains(term) || x.WorkRequest.Address.ToLower().Contains(term) ||
            x.WorkRequest.Cause.ToLower().Contains(term) || x.WorkRequest.Note.ToLower().Contains(term) ||
            x.WorkRequest.Company.ToLower().Contains(term) || x.WorkRequest.PhoneNumber.ToLower().Contains(term)) && x.User.Deleted == false);

            if (sort == "DESC")
            {
                query = query.OrderByDescending(x => x.User.Id);
            }
            else
            {
                query = query.OrderBy(x => x.User.Id);
            }

            return new PageResponse<DocumentHistory>(query.Skip(page * perPage).Take(perPage).ToList(), query.Count());
        }
    }
}
