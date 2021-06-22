using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;
using Web2_Backend.Repository;

namespace Web2_Backend.Service
{
    public class CrewService
    {
        public Crew Get(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.Crews.Get(id);
                }
            }
            catch (Exception e)
            {
                return null;
            }


            return null;
        }

        public IEnumerable<Crew> GetAll(int page, int perPage, string search)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.Crews.GetAll(page, perPage, search);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Add(Crew crews)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    Crew newCrew = new Crew();

                    newCrew.Name = crews.Name;

                    unitOfWork.Crews.Add(newCrew);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Edit(int id, Crew crews)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    Crew crewDB = Get(id);
                    unitOfWork.Crews.Update(crewDB);


                    crewDB.Id = crews.Id;
                    crewDB.Name = crews.Name;

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
                    Crew crews = Get(id);
                    unitOfWork.Crews.Remove(crews);
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
