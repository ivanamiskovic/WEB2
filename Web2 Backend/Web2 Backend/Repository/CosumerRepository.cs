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
    }
}
