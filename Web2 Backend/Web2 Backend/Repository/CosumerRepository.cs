using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Core;
using Web2_Backend.Model;

namespace Web2_Backend.Repository
{
 
    public class CosumerRepository : Repository<Cosumer>, ICosumerRepository
    {
        public CosumerRepository(Web2Context context) : base(context) { }

        public override IEnumerable<Cosumer> GetAll()
        {
            return Web2Context.Cosumers.Where(x => x.Deleted == false).ToList();
        }

        public override PageResponse<Cosumer> GetAll(int page, int perPage, string search)
        {
            string term = search.ToLower();

            var query = Web2Context.Cosumers.Where(x => x.Name.ToLower().Contains(term)
            || x.Location.ToLower().Contains(term) || x.LastName.ToLower().Contains(term) || x.PhoneNumber.ToLower().Contains(term) || x.Type.ToLower().Contains(term));

            return new PageResponse<Cosumer>(query.Skip(page * perPage).Take(perPage).ToList(), query.Count());
        }
    }
}
