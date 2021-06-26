using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;
using Web2_Backend.Repository;

namespace Web2_Backend.Service
{
    public class CallsService
    {
        public Calls Get(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context())) 
                {
                    return unitOfWork.Calls.Get(id);
                }
            }
            catch (Exception e) 
            {
                return null;
            }


            return null;
        }

        public PageResponse<Calls> GetAll(int page, int perPage, string search)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.Calls.GetAll(page, perPage, search);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Add(Calls calls)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    Calls newCall = new Calls();

                    newCall.BreakdownName = calls.BreakdownName;
                    newCall.BreakdownPriority = calls.BreakdownPriority;
                    newCall.Comment = calls.Comment;
                    newCall.Deleted = calls.Deleted;
                    newCall.Id = calls.Id;
                    newCall.Reason = calls.Reason;

                    unitOfWork.Calls.Add(newCall);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Edit(int id, Calls calls)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    Calls callDB = Get(id);
                    unitOfWork.Calls.Update(callDB);

                    callDB.BreakdownName = calls.BreakdownName;
                    callDB.BreakdownPriority = calls.BreakdownPriority;
                    callDB.Comment = calls.Comment;
                    callDB.Deleted = calls.Deleted;
                    callDB.Id = calls.Id;
                    callDB.Reason = calls.Reason;

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
                    Calls calls = Get(id);
                    unitOfWork.Calls.Remove(calls);
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
