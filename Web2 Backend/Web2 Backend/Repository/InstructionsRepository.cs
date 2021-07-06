using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Core;
using Web2_Backend.Model;

namespace Web2_Backend.Repository
{
    public class InstructionsRepository : Repository<Instructions>, IInstructionRepository
    {
        public InstructionsRepository(Web2Context context) : base(context) { }

        public override IEnumerable<Instructions> GetAll()
        {
            return Web2Context.Instructions.Where(x => x.Deleted == false).ToList();
        }

        public override PageResponse<Instructions> GetAll(int page, int perPage, string search, string sort)
        {
            string term = search == null ? "" : search.ToLower();

            var query = Web2Context.Instructions.Where(x => x.Name.ToLower().Contains(term));

            if (sort == "DESC")
            {
                query = query.OrderByDescending(x => x.Id);
            }
            else
            {
                query = query.OrderBy(x => x.Id);
            }


            return new PageResponse<Instructions>(query.Skip(page * perPage).Take(perPage).ToList(), query.Count());
        }

    }
}



