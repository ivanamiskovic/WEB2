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

        public PageResponse<Incident> GetAll()
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    IEnumerable<Incident> result = unitOfWork.Incidents.GetAll();
                    PageResponse<Incident> pageResponse = new PageResponse<Incident>(result, result.Count());

                    return pageResponse;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Add(Incident incident)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new Web2Context()))
                {
                    Incident newIncident = new Incident();

                    newIncident.AffectedCustomers = incident.AffectedCustomers;
                    newIncident.ATA = incident.ATA;
                    newIncident.Calls = incident.Calls;
                    newIncident.Confirmed = incident.Confirmed;
                    newIncident.Deleted = incident.Deleted;
                    newIncident.EstimatedWorkTime = incident.EstimatedWorkTime;
                    newIncident.ETA = incident.ETA;
                    newIncident.ETR = incident.ETR;
                    newIncident.Id = incident.Id;
                    newIncident.IncidentDateAndTime = incident.IncidentDateAndTime;
                    newIncident.IncidentType = incident.IncidentType;
                    newIncident.Operater = incident.Operater;
                    newIncident.Priority = incident.Priority;
                    newIncident.Status = incident.Status;
                    newIncident.VoltegeLevel = incident.VoltegeLevel;

                    unitOfWork.Incidents.Add(newIncident);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
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
    }
}
