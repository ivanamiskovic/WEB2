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
                    IEnumerable<WorkRequest> result = unitOfWork.WorkRequests.GetAll(page, perPage, search);
                    PageResponse<WorkRequest> pageResponse = new PageResponse<WorkRequest>(result, 1);

                    return pageResponse;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public WorkRequest Add(WorkRequest workRequest)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    WorkRequest newWorkRequest = new WorkRequest();

                    newWorkRequest.Type = workRequest.Type;
                    newWorkRequest.Status = workRequest.Status;
                    newWorkRequest.Address = workRequest.Address;
                    newWorkRequest.Start = workRequest.Start;
                    newWorkRequest.Company = workRequest.Company;
                    newWorkRequest.End = workRequest.End;
                    newWorkRequest.Cause = workRequest.Cause;
                    newWorkRequest.Note = workRequest.Note;
                    newWorkRequest.Urgent = workRequest.Urgent;
                    newWorkRequest.PhoneNumber = workRequest.PhoneNumber;


                    unitOfWork.WorkRequests.Add(newWorkRequest);
                    unitOfWork.Complete();

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
                    workRequestDb.Status = workRequest.Status;
                    workRequestDb.Address = workRequest.Address;
                    workRequestDb.Start = workRequest.Start;
                    workRequestDb.Company = workRequest.Company;
                    workRequestDb.End = workRequest.End;
                    workRequestDb.Cause = workRequest.Cause;
                    workRequestDb.Note = workRequest.Note;
                    workRequestDb.Urgent = workRequest.Urgent;
                    workRequestDb.PhoneNumber = workRequest.PhoneNumber;

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
                    unitOfWork.WorkRequests.Remove(workRequest);
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
