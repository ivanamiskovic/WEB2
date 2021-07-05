using System;
using Web2_Backend.Model;

namespace Web2_Backend.Core
{
    public interface IWorkRequestRepository : IRepository<WorkRequest>
    {
        PageResponse<WorkRequest> GetAll(int page, int perPage, string search, User user, string sort, int workRequestId);
    }
}
