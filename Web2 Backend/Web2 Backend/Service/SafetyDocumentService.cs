using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;
using Web2_Backend.Repository;

namespace Web2_Backend.Service
{
    public class SafetyDocumentService 
    {
        public SafetyDocument Get(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.SafetyDocument.Get(id);
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return null;
        }

        public PageResponse<SafetyDocument> GetAll(int page, int perPage, string search, bool mine, User user, string sort)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    if (!mine)
                    {
                        return unitOfWork.SafetyDocument.GetAll(page, perPage, search, sort);
                    }
                    else
                    {
                        return unitOfWork.SafetyDocument.GetAll(page, perPage, search, user, sort);
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Add(SafetyDocument safetyDocument)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    SafetyDocument newSafetyDocument = new SafetyDocument();

                    newSafetyDocument.CreateDateAndTime = safetyDocument.CreateDateAndTime;
                    newSafetyDocument.Deleted = safetyDocument.Deleted;
                    newSafetyDocument.Details = safetyDocument.Details;
                    newSafetyDocument.DocumentStatus = safetyDocument.DocumentStatus;
                    newSafetyDocument.DocumentType = safetyDocument.DocumentType;
                    newSafetyDocument.Id = safetyDocument.Id;
                    newSafetyDocument.Notes = safetyDocument.Notes;
                    newSafetyDocument.PhoneNumber = safetyDocument.PhoneNumber;

                    unitOfWork.SafetyDocument.Add(newSafetyDocument);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Edit(int id, SafetyDocument safetyDocument)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    SafetyDocument safetyDocumentDB = Get(id);
                    unitOfWork.SafetyDocument.Update(safetyDocumentDB);

                    safetyDocumentDB.CreateDateAndTime = safetyDocument.CreateDateAndTime;
                    safetyDocumentDB.Deleted = safetyDocument.Deleted;
                    safetyDocumentDB.Details = safetyDocument.Details;
                    safetyDocumentDB.DocumentStatus = safetyDocument.DocumentStatus;
                    safetyDocumentDB.DocumentType = safetyDocument.DocumentType;
                    safetyDocumentDB.Id = safetyDocument.Id;
                    safetyDocumentDB.Notes = safetyDocument.Notes;
                    safetyDocumentDB.PhoneNumber = safetyDocument.PhoneNumber;


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
                    SafetyDocument safetyDocument = Get(id);
                    unitOfWork.SafetyDocument.Remove(safetyDocument);
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

