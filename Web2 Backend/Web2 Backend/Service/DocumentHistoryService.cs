using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;
using Web2_Backend.Repository;

namespace Web2_Backend.Service
{
    public class DocumentHistoryService
    {
        public DocumentHistory Get(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.DocumentHistories.Get(id);
                }
            }
            catch (Exception e)
            {
                return null;
            }


            return null;
        }

        public PageResponse<DocumentHistory> GetAll(int page, int perPage, string search, string sort, int workRequestId)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.DocumentHistories.GetAll(page, perPage, search, sort, workRequestId);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public bool Add(DocumentHistory documentHistory)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    DocumentHistory newDocumentHistory = new DocumentHistory();

                    newDocumentHistory.User.Address = documentHistory.User.Address;
                    newDocumentHistory.User.Email = documentHistory.User.Email;
                    newDocumentHistory.User.Id = documentHistory.User.Id;
                    newDocumentHistory.User.LastName = documentHistory.User.LastName;
                    newDocumentHistory.User.Name = documentHistory.User.Name;
                    newDocumentHistory.User.Username = documentHistory.User.Username;

                    newDocumentHistory.WorkRequest.Type = documentHistory.WorkRequest.Type;
                    newDocumentHistory.WorkRequest.Status = "Draft";
                    newDocumentHistory.WorkRequest.Address = documentHistory.WorkRequest.Address;
                    newDocumentHistory.WorkRequest.Start = documentHistory.WorkRequest.Start;
                    newDocumentHistory.WorkRequest.Company = documentHistory.WorkRequest.Company;
                    newDocumentHistory.WorkRequest.End = documentHistory.WorkRequest.End;
                    newDocumentHistory.WorkRequest.Cause = documentHistory.WorkRequest.Cause;
                    newDocumentHistory.WorkRequest.Note = documentHistory.WorkRequest.Note;
                    newDocumentHistory.WorkRequest.Urgent = documentHistory.WorkRequest.Urgent;
                    newDocumentHistory.WorkRequest.PhoneNumber = documentHistory.WorkRequest.PhoneNumber;
                    newDocumentHistory.WorkRequest.Incident = documentHistory.WorkRequest.Incident;
                    newDocumentHistory.WorkRequest.CreatedBy = documentHistory.WorkRequest.CreatedBy;
                    newDocumentHistory.WorkRequest.Purpose = documentHistory.WorkRequest.Purpose;
                    newDocumentHistory.WorkRequest.Created = DateTime.Now;

                    unitOfWork.DocumentHistories.Add(newDocumentHistory);
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
                    DocumentHistory documentHistoryDB = Get(id);
                    unitOfWork.DocumentHistories.Update(documentHistoryDB);

                    documentHistoryDB.User.Address = documentHistoryDB.User.Address;
                    documentHistoryDB.User.Email = documentHistoryDB.User.Email;
                    documentHistoryDB.User.Id = documentHistoryDB.User.Id;
                    documentHistoryDB.User.LastName = documentHistoryDB.User.LastName;
                    documentHistoryDB.User.Name = documentHistoryDB.User.Name;
                    documentHistoryDB.User.Username = documentHistoryDB.User.Username;


                    documentHistoryDB.WorkRequest.Type = documentHistoryDB.WorkRequest.Type;
                    documentHistoryDB.WorkRequest.Status = "Draft";
                    documentHistoryDB.WorkRequest.Address = documentHistoryDB.WorkRequest.Address;
                    documentHistoryDB.WorkRequest.Start = documentHistoryDB.WorkRequest.Start;
                    documentHistoryDB.WorkRequest.Company = documentHistoryDB.WorkRequest.Company;
                    documentHistoryDB.WorkRequest.End = documentHistoryDB.WorkRequest.End;
                    documentHistoryDB.WorkRequest.Cause = documentHistoryDB.WorkRequest.Cause;
                    documentHistoryDB.WorkRequest.Note = documentHistoryDB.WorkRequest.Note;
                    documentHistoryDB.WorkRequest.Urgent = documentHistoryDB.WorkRequest.Urgent;
                    documentHistoryDB.WorkRequest.Incident = documentHistoryDB.WorkRequest.Incident;
                    documentHistoryDB.WorkRequest.CreatedBy = documentHistoryDB.WorkRequest.CreatedBy;
                    documentHistoryDB.WorkRequest.Purpose = documentHistoryDB.WorkRequest.Purpose;
                    documentHistoryDB.WorkRequest.Created = DateTime.Now;
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
                    DocumentHistory documentHistories = Get(id);
                    unitOfWork.DocumentHistories.Remove(documentHistories);
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
