﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;

namespace Web2_Backend.Core
{
    public interface IIncidentRepository : IRepository<Incident>
    {
        PageResponse<Incident> GetAll(int page, int perPage, string search, User user, string sort);
    }
}
