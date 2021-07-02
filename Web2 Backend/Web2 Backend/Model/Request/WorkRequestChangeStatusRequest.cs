using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2_Backend.Model.Request
{
    public class WorkRequestChangeStatusRequest
    {
        public int WorkRequestId { get; set; }
        public DocumentStatus Status { get; set; }
    }
}
