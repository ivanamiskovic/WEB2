using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;
using Web2_Backend.Repository;

namespace Web2_Backend.Service
{
    public class MultimediaAttachmentsService
    {
        public MultimediaAttachments Get(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.MultimediaAttachments.Get(id);
                }
            }
            catch (Exception e)
            {
                return null;
            }


            return null;
        }

        public PageResponse<MultimediaAttachments> GetAll(int page, int perPage, string search, string sort)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.MultimediaAttachments.GetAll(page, perPage, search, sort);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Add(MultimediaAttachments multimedia)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    MultimediaAttachments newMultimedia = new MultimediaAttachments();

                    newMultimedia.Name = multimedia.Name;
                    newMultimedia.Content = multimedia.Content;

                    unitOfWork.MultimediaAttachments.Add(newMultimedia);

                    unitOfWork.Complete();

                    WorkRequest workRequest = unitOfWork.WorkRequests.Get(multimedia.WorkRequest.Id);

                    unitOfWork.MultimediaAttachments.Update(newMultimedia);
                    newMultimedia.WorkRequest = workRequest;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Edit(int id, MultimediaAttachments multimedia)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    MultimediaAttachments multimediaDB = Get(id);
                    unitOfWork.MultimediaAttachments.Update(multimediaDB);

                    multimediaDB.Name = multimedia.Name;
                    multimediaDB.Content = multimedia.Content;
                    multimediaDB.Deleted = multimedia.Deleted;
                    multimediaDB.Id = multimedia.Id;
                    unitOfWork.Complete();

                    WorkRequest workRequest = unitOfWork.WorkRequests.Get(multimedia.WorkRequest.Id);

                    unitOfWork.MultimediaAttachments.Update(multimediaDB);
                    multimediaDB.WorkRequest = workRequest;

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
                    MultimediaAttachments multimedia = Get(id);

                    unitOfWork.MultimediaAttachments.Update(multimedia);
                    multimedia.Deleted = true;

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
