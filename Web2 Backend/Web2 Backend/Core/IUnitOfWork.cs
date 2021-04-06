using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2_Backend.Core
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
