using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;
using Web2_Backend.Repository;

namespace Web2_Backend.Service
{
    public class CosumerService
    {
        public Cosumer Get(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.Cosumer.Get(id);
                }
            }
            catch (Exception e)
            {
                return null;
            }


            return null;
        }

        public PageResponse<Cosumer> GetAll()
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    IEnumerable<Cosumer> result = unitOfWork.Cosumer.GetAll();
                    PageResponse<Cosumer> pageResponse = new PageResponse<Cosumer>(result, result.Count());

                    return pageResponse;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Add(Cosumer cosumer)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    Cosumer newCosumer = new Cosumer();

                    newCosumer.Name = cosumer.Name;
                    newCosumer.Location = cosumer.Location;
                    newCosumer.Priority = cosumer.Priority;
                    newCosumer.LastName = cosumer.LastName;
                    newCosumer.PhoneNumber = cosumer.PhoneNumber;
                    newCosumer.Id = cosumer.Id;
                    newCosumer.Type = cosumer.Type;
                   


                    unitOfWork.Cosumer.Add(newCosumer);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Edit(int id, Cosumer cosumer)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    Cosumer cosumerDB = Get(id);
                    unitOfWork.Cosumer.Update(cosumerDB);

                    cosumerDB.Name = cosumer.Name;
                    cosumerDB.Location = cosumer.Location;
                    cosumerDB.Priority = cosumer.Priority;
                    cosumerDB.LastName = cosumer.LastName;
                    cosumerDB.PhoneNumber = cosumer.PhoneNumber;
                    cosumerDB.Id = cosumer.Id;
                    cosumerDB.Type = cosumer.Type;



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
                    Cosumer cosumer = Get(id);
                    unitOfWork.Cosumer.Remove(cosumer);
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
