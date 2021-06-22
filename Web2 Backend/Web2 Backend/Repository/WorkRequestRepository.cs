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
    }
}