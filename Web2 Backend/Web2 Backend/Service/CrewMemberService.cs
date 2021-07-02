using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;
using Web2_Backend.Repository;

namespace Web2_Backend.Service
{
    public class CrewMemberService
    {
        public CrewMember Get(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.CrewMembers.Get(id);
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }

        public PageResponse<CrewMember> GetAll(int page, int perPage, string search, string sort)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {

                    return unitOfWork.CrewMembers.GetAll(page, perPage, search, sort);
                } 
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Add(CrewMember crewMembers)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    CrewMember newCrewMember = new CrewMember();

                    newCrewMember.User = crewMembers.User;
                    newCrewMember.Crew = crewMembers.Crew;

                    unitOfWork.CrewMembers.Add(newCrewMember);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Edit(int id, CrewMember crewMembers)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    CrewMember crewMemberDB = Get(id);
                    unitOfWork.CrewMembers.Update(crewMemberDB);


                    crewMemberDB.Id = crewMembers.Id;
                    crewMemberDB.User = crewMembers.User;
                    crewMembers.Crew = crewMembers.Crew;

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
                    CrewMember crewMembers = Get(id);
                    unitOfWork.CrewMembers.Remove(crewMembers);
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
