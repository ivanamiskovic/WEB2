using System;
using System.Collections.Generic;
using System.Linq;
using Web2_Backend.Core;
using Web2_Backend.Model;

namespace Web2_Backend.Repository
{
    public class DeviceRepository : Repository<Device>, IDeviceRepository
    {
        public DeviceRepository(Web2Context context) : base(context) { }

        public override IEnumerable<Device> GetAll()
        {
            return Web2Context.Devices.Where(x => x.Deleted == false).ToList();
        }

        public override PageResponse<Device> GetAll(int page, int perPage, string search, string sort)
        {
            string term = search == null ? string.Empty : search.ToLower();


            var query = Web2Context.Devices.Where(x => x.Type.ToLower().Contains(term)
            || x.Name.ToLower().Contains(term) || x.Address.ToLower().Contains(term));

            if (sort == "DESC")
            {
                query = query.OrderByDescending(x => x.Id);
            }
            else
            {
                query = query.OrderBy(x => x.Id);
            }

            return new PageResponse<Device>(query.Skip(page * perPage).Take(perPage).ToList(), query.Count());
        }
    }
}
