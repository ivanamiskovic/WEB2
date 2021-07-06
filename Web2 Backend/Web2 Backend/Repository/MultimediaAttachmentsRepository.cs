using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Core;
using Web2_Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Web2_Backend.Repository
{
    public class MultimediaAttachmentsRepository : Repository<MultimediaAttachments>, IMultimediaAttachmentsRepository
    {
        public MultimediaAttachmentsRepository(Web2Context context) : base(context) { }

        public override IEnumerable<MultimediaAttachments> GetAll()
        {
            return Web2Context.MultimediaAttachments.Where(x => x.Deleted == false).ToList();
        }

        public override PageResponse<MultimediaAttachments> GetAll(int page, int perPage, string search, string sort)
        {
            string term = search == null ? string.Empty : search.ToLower();


            var query = Web2Context.MultimediaAttachments.Where(x => x.Name.ToLower().Contains(term)
            || x.Content.ToLower().Contains(term));

            if (sort == "DESC")
            {
                query = query.OrderByDescending(x => x.Id);
            }
            else
            {
                query = query.OrderBy(x => x.Id);
            }

            return new PageResponse<MultimediaAttachments>(query.Skip(page * perPage).Take(perPage).ToList(), query.Count());
        }
    }
}
