using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Model;
using Web2_Backend.Repository;

namespace Web2_Backend.Service
{
    public class IncidentService
    {
        public Incident Get(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    return unitOfWork.Incidents.Get(id);
                }
            }
            catch (Exception e)
            {
                return null;
            }


            return null;
        }

        public PageResponse<Incident> GetAll(int page, int perPage, string search, bool mine, User user, string sort)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    if (!mine)
                    {
                        return unitOfWork.Incidents.GetAll(page, perPage, search, sort);
                    }
                    else
                    {
                        return unitOfWork.Incidents.GetAll(page, perPage, search, user, sort);
                    }

                    
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Incident Add(Incident incident)
        {
            //try
            //{
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    Incident newIncident = new Incident();

                    newIncident.AffectedCustomers = incident.AffectedCustomers;
                    newIncident.ATA = incident.ATA;
                    newIncident.Calls = incident.Calls;
                    newIncident.Confirmed = incident.Confirmed;
                    newIncident.Deleted = false;
                    newIncident.EstimatedWorkTime = incident.EstimatedWorkTime;
                    newIncident.ETA = incident.ETA;
                    newIncident.ETR = incident.ETR;
                    newIncident.Id = incident.Id;
                    newIncident.IncidentDateAndTime = incident.IncidentDateAndTime;
                    newIncident.IncidentType = incident.IncidentType;
                    
                    newIncident.Priority = incident.Priority;
                    newIncident.Status = 1;
                    newIncident.VoltegeLevel = incident.VoltegeLevel;
                    newIncident.Description = incident.Description;

                    unitOfWork.Incidents.Add(newIncident);
                    unitOfWork.Complete();

                    unitOfWork.Incidents.Update(newIncident);
                newIncident.Operater = incident.Operater;
                unitOfWork.Complete();
                return newIncident;
                }
            //}
            //catch (Exception e)
            //{
            //    return null;
            //}

        }

        public bool Edit(int id, Incident incident)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    Incident incidentDB = Get(id);
                    unitOfWork.Incidents.Update(incidentDB);

                    incidentDB.AffectedCustomers = incident.AffectedCustomers;
                    incidentDB.ATA = incident.ATA;
                    incidentDB.Calls = incident.Calls;
                    incidentDB.Confirmed = incident.Confirmed;
                    incidentDB.Deleted = incident.Deleted;
                    incidentDB.EstimatedWorkTime = incident.EstimatedWorkTime;
                    incidentDB.ETA = incident.ETA;
                    incidentDB.ETR = incident.ETR;
                    incidentDB.Id = incident.Id;
                    incidentDB.IncidentDateAndTime = incident.IncidentDateAndTime;
                    incidentDB.IncidentType = incident.IncidentType;
                    incidentDB.Operater = incident.Operater;
                    incidentDB.Priority = incident.Priority;
                    incidentDB.Status = incident.Status;
                    incidentDB.VoltegeLevel = incident.VoltegeLevel;

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
                    Incident incident = Get(id);
                    unitOfWork.Incidents.Remove(incident);
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool SetOperater(int id, User operater)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    Incident incident = Get(id);
                    
                    if (incident == null)
                    {
                        return false;
                    }

                    unitOfWork.Incidents.Update(incident);

                    incident.Operater = operater;

                    unitOfWork.Complete();

                    return true;

                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
