﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2_Backend.Core;
using Web2_Backend.Model;

namespace Web2_Backend.Repository
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly Web2Context context;

        public IUserRepository Users { get; private set; }
        public IIncidentRepository Incidents { get; private set; }
        public ISwitchingPlanRepository SwitchingPlans { get; private set; }
        public ISolutionRepository Solutions { get; private set; }
        public ICallsRepository Calls { get; private set; }
        public ISafetyDocumentRepository SafetyDocument { get; private set; }
        public ICosumerRepository Cosumer { get; private set; }
        public IWorkingPlanRepository WorkingPlans { get; private set; }
        public ICrewRepository Crews { get; private set; }
        public IDeviceRepository Devices { get; private set; }
        public IWorkRequestRepository WorkRequests { get; private set; }
        public IInstructionRepository Instructions{ get; private set; }

        public ICrewMemberRepository CrewMembers { get; private set; }
        public IDocumentHistoryRepository DocumentHistories { get; private set; }
        public IMultimediaAttachmentsRepository MultimediaAttachments { get; private set; }

        public UnitOfWork(Web2Context context) 
        {
            this.context = context;
            Users = new UserRepository(this.context);
            Incidents = new IncidentRepository(this.context);
            SwitchingPlans = new SwitchingPlanRepository(this.context);
            Solutions = new SolutionRepository(this.context);
            Calls = new CallsRepository(this.context);
            SafetyDocument = new SafetyDocumentRepository(this.context);
            Cosumer = new CosumerRepository(this.context);
            WorkingPlans = new WorkingPlanRepository(this.context);
            Crews = new CrewRepository(this.context);
            Devices = new DeviceRepository(this.context);
            WorkRequests = new WorkRequestRepository(this.context);
            CrewMembers = new CrewMemberRepository(this.context);
            DocumentHistories = new DocumentHistoryRepository(this.context);
            MultimediaAttachments = new MultimediaAttachmentsRepository(this.context);
        }

        public Web2Context Context
        {
            get { return context; }
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
