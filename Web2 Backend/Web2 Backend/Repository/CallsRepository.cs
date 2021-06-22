using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Core;
using Web2_Backend.Model;

namespace Web2_Backend.Repository
{
    public class CallsRepository : Repository<Calls>, ICallsRepository
    {
        public CallsRepository(Web2Context context) : base(context) { }

        public override IEnumerable<Calls> GetAll()
        {
            return Web2Context.Calls.Where(x => x.Deleted == false).ToList();
        }
    }
}
