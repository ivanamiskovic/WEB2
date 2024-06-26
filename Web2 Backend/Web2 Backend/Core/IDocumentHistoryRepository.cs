﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;

namespace Web2_Backend.Core
{
    public interface IDocumentHistoryRepository : IRepository<DocumentHistory>
    {
        PageResponse<DocumentHistory> GetAll(int page, int perPage, string search, string sort, int workRequestId);

    }
}
