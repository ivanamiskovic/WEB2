﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2_Backend.Model
{
    public class PageResponse<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> Entities { get; set; }
        public int Total { get; set; }

        public PageResponse(IEnumerable<TEntity> entities, int total) 
        {
            Entities = entities;
            Total = total;
        }
    }
}
