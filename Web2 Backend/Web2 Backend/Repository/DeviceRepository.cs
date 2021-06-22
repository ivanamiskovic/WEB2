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
    }
}
