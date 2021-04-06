using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2_Backend.Model.Request
{
    public class ChangeUserTypeRequest
    {
        public int Id { get; set; }
        public UserType UserType { get; set; }
    }
}
