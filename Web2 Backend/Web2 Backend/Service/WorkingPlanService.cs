using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;
using Web2_Backend.Repository;


namespace Web2_Backend.Service
{
    public class WorkingPlanService
    {
        public WorkingPlan Get(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.WorkingPlans.Get(id);
                }
            }
            catch (Exception e)
            {
                return null;
            }


            return null;
        }

        public PageResponse<WorkingPlan> GetAll()
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    IEnumerable<WorkingPlan> result = unitOfWork.WorkingPlans.GetAll();
                    PageResponse<WorkingPlan> pageResponse = new PageResponse<WorkingPlan>(result, result.Count());

                    return pageResponse;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Add(WorkingPlan workingPlan)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    WorkingPlan newWorkingPlan = new WorkingPlan();

                    newWorkingPlan.Street = newWorkingPlan.Street;
                    newWorkingPlan.StartOfWork = newWorkingPlan.StartOfWork;
                    newWorkingPlan.EndOfWork = newWorkingPlan.EndOfWork;
                    newWorkingPlan.Notes = newWorkingPlan.Notes;
                    newWorkingPlan.Company = newWorkingPlan.Company;
                    newWorkingPlan.Number = newWorkingPlan.Number;
                    newWorkingPlan.CreateDocument = newWorkingPlan.CreateDocument;
                    newWorkingPlan.Point = newWorkingPlan.Point;
                    newWorkingPlan.UserCreate = newWorkingPlan.UserCreate;
                    


                    unitOfWork.WorkingPlans.Add(newWorkingPlan);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Edit(int id, WorkingPlan workingPlan)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    WorkingPlan workingPlanDB = Get(id);
                    unitOfWork.WorkingPlans.Update(workingPlanDB);

                    workingPlanDB.Street = workingPlanDB.Street;
                    workingPlanDB.StartOfWork = workingPlanDB.StartOfWork;
                    workingPlanDB.EndOfWork = workingPlanDB.EndOfWork;
                    workingPlanDB.Notes = workingPlanDB.Notes;
                    workingPlanDB.Company = workingPlanDB.Company;
                    workingPlanDB.Number = workingPlanDB.Number;
                    workingPlanDB.CreateDocument = workingPlanDB.CreateDocument;
                    workingPlanDB.Point = workingPlanDB.Point;
                    workingPlanDB.UserCreate = workingPlanDB.UserCreate;


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
                    WorkingPlan workingPlan = Get(id);
                    unitOfWork.WorkingPlans.Remove(workingPlan);
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
