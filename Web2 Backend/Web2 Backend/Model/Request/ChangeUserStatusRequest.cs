using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2_Backend.Model.Request
{
    public class ChangeUserStatusRequest
    {
        public int Id { get; set; }
        public UserStatus UserStatus { get; set; }
    }
}
