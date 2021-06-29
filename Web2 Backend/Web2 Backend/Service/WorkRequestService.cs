using System;
using System.Collections.Generic;
using Web2_Backend.Model;
using Web2_Backend.Repository;

namespace Web2_Backend.Service
{
    public class WorkRequestService
    {
        public WorkRequest Get(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.WorkRequests.Get(id);
                }
            }
            catch (Exception e)
            {
                return null;
            }


            return null;
        }

        public PageResponse<WorkRequest> GetAll(int page, int perPage, string search)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.WorkRequests.GetAll(page, perPage, search);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public WorkRequest Add(WorkRequest workRequest, User user)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    WorkRequest newWorkRequest = new WorkRequest();

                    newWorkRequest.Type = workRequest.Type;
                    newWorkRequest.Status = "Draft";
                    newWorkRequest.Address = workRequest.Address;
                    newWorkRequest.Start = workRequest.Start;
                    newWorkRequest.Company = workRequest.Company;
                    newWorkRequest.End = workRequest.End;
                    newWorkRequest.Cause = workRequest.Cause;
                    newWorkRequest.Note = workRequest.Note;
                    newWorkRequest.Urgent = workRequest.Urgent;
                    newWorkRequest.PhoneNumber = workRequest.PhoneNumber;
                    newWorkRequest.Incident = workRequest.Incident;
                    newWorkRequest.CreatedBy = workRequest.CreatedBy;
                    newWorkRequest.Purpose = workRequest.Purpose;
                    newWorkRequest.Created = DateTime.Now;


                    unitOfWork.WorkRequests.Add(newWorkRequest);
                    unitOfWork.Complete();

                    unitOfWork.WorkRequests.Update(newWorkRequest);
                    newWorkRequest.CreatedBy = user.Name + " " + user.LastName;

                    return newWorkRequest;
                }
            }
            catch (Exception e)
            {
                return null;
            }

            
        }

        public bool Edit(int id, WorkRequest workRequest)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    WorkRequest workRequestDb = Get(id);
                    unitOfWork.WorkRequests.Update(workRequestDb);

                    workRequestDb.Type = workRequest.Type;
                    workRequestDb.Status = "Draft";
                    workRequestDb.Address = workRequest.Address;
                    workRequestDb.Start = workRequest.Start;
                    workRequestDb.Company = workRequest.Company;
                    workRequestDb.End = workRequest.End;
                    workRequestDb.Cause = workRequest.Cause;
                    workRequestDb.Note = workRequest.Note;
                    workRequestDb.Urgent = workRequest.Urgent;
                    workRequestDb.PhoneNumber = workRequest.PhoneNumber;
                    workRequestDb.Incident = workRequest.Incident;
                    workRequestDb.CreatedBy = workRequest.CreatedBy;
                    workRequestDb.Purpose = workRequest.Purpose;
                    workRequestDb.Created = DateTime.Now;


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
                    WorkRequest workRequest = Get(id);
                    unitOfWork.WorkRequests.Update(workRequest);
                    workRequest.Deleted = true;
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
