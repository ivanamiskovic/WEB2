using System;
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
        public ISolutionRepository Solutions { get; private set; }
        public ICallsRepository Calls { get; private set; }
        public ISafetyDocumentRepository SafetyDocument { get; private set; }

        public UnitOfWork(Web2Context context) 
        {
            this.context = context;
            Users = new UserRepository(this.context);
            Incidents = new IncidentRepository(this.context);
            Solutions = new SolutionRepository(this.context);
            Calls = new CallsRepository(this.context);
            SafetyDocument = new SafetyDocumentRepository(this.context);
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
