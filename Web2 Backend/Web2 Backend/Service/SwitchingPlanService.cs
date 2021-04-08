using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;
using Web2_Backend.Repository;

namespace Web2_Backend.Service
{
   
        public class SwitchingPlanService
    {
            public SwitchingPlan Get(int id)
            {
                try
                {
                    using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                    {
                        return unitOfWork.SwitchingPlans.Get(id);
                    }
                }
                catch (Exception e)
                {
                    return null;
                }


                return null;
            }

            public PageResponse<SwitchingPlan> GetAll()
            {
                try
                {
                    using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                    {
                        IEnumerable<SwitchingPlan> result = unitOfWork.SwitchingPlans.GetAll();
                        PageResponse<SwitchingPlan> pageResponse = new PageResponse<SwitchingPlan>(result, result.Count());

                        return pageResponse;
                    }
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            public bool Add(SwitchingPlan switchingPlan)
            {
                try
                {
                    using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                    {
                    SwitchingPlan newSwitchingPlan = new SwitchingPlan();

                    newSwitchingPlan.Street = switchingPlan.Street;
                    newSwitchingPlan.StartOfWork = switchingPlan.StartOfWork;
                    newSwitchingPlan.EndOfWork = switchingPlan.EndOfWork;
                    newSwitchingPlan.Notes = switchingPlan.Notes;
                    newSwitchingPlan.Company = switchingPlan.Company;
                    newSwitchingPlan.Number = switchingPlan.Number;
                    newSwitchingPlan.CreateDocument = switchingPlan.CreateDocument;
                    newSwitchingPlan.Point = switchingPlan.Point;
                    newSwitchingPlan.UserCreate = switchingPlan.UserCreate;
                    newSwitchingPlan.Team = switchingPlan.Team;
                   

                        unitOfWork.SwitchingPlans.Add(newSwitchingPlan);
                        unitOfWork.Complete();
                    }
                }
                catch (Exception e)
                {
                    return false;
                }

                return true;
            }

            public bool Edit(int id, SwitchingPlan switchingPlan)
            {
                try
                {
                    using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                    {
                    SwitchingPlan switchingPlanDB = Get(id);
                        unitOfWork.SwitchingPlans.Update(switchingPlanDB);

                    switchingPlanDB.Street = switchingPlan.Street;
                    switchingPlanDB.StartOfWork = switchingPlan.StartOfWork;
                    switchingPlanDB.EndOfWork = switchingPlan.EndOfWork;
                    switchingPlanDB.Notes = switchingPlan.Notes;
                    switchingPlanDB.Company = switchingPlan.Company;
                    switchingPlanDB.Number = switchingPlan.Number;
                    switchingPlanDB.CreateDocument = switchingPlan.CreateDocument;
                    switchingPlanDB.Point = switchingPlan.Point;
                    switchingPlanDB.UserCreate = switchingPlan.UserCreate;
                    switchingPlanDB.Team = switchingPlan.Team;
                   

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
                    SwitchingPlan switchingPlan = Get(id);
                        unitOfWork.SwitchingPlans.Remove(switchingPlan);
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
