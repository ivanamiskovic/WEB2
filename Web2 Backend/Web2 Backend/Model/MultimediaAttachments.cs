using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2_Backend.Model
{
    public class MultimediaAttachments : Entity
    {
        public string Name { get; set; }
        public string Content { get; set; }

        public WorkRequest WorkRequest { get; set; }
    }
}
