using System;
using System.Collections.Generic;
using Web2_Backend.Model;
using Web2_Backend.Repository;

namespace Web2_Backend.Service
{
    public class DeviceService
    {
        public Device Get(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.Devices.Get(id);
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public PageResponse<Device> GetAll(int page, int perPage, string search)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.Devices.GetAll(page, perPage, search);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Add(Device device)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    Device newDevice = new Device();

                    newDevice.Name = device.Name;
                    newDevice.Address = device.Address;
                    newDevice.Deleted = false;
                    newDevice.Type = device.Type;
                    newDevice.Lat = device.Lat;
                    newDevice.Lng = device.Lng;

                    unitOfWork.Devices.Add(newDevice);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Edit(int id, Device device)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    Device deviceDB = Get(id);
                    unitOfWork.Devices.Update(deviceDB);


                    deviceDB.Name = device.Name;
                    deviceDB.Name = device.Name;
                    deviceDB.Address = device.Address;
                    deviceDB.Type = device.Type;
                    deviceDB.Lat = device.Lat;
                    deviceDB.Lng = device.Lng;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    Device device = Get(id);
                    unitOfWork.Devices.Update(device);

                    device.Deleted = true;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
