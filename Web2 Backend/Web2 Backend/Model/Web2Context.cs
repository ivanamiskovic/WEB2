using Microsoft.EntityFrameworkCore;
using Web2_Backend.Configuration;

namespace Web2_Backend.Model
{
    public class Web2Context : DbContext
    { 
        public static ProjectConfiguration Configuration;

        public Web2Context() { }

        public Web2Context(DbContextOptions<Web2Context> context, ProjectConfiguration configuration) : base(context) {

            if (configuration != null)
            {
                Web2Context.Configuration = configuration;
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Calls> Calls { get; set; }
        public DbSet<WorkingPlan> WorkingPlans { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<WorkRequest> WorkRequests { get; set; }
        public DbSet<SafetyDocument> SafetyDocuments { get; set; }
        public DbSet<SwitchingPlan> SwitchingPlans { get; set; }
        public DbSet<Cosumer> Cosumers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (optionsBuilder.IsConfigured) 
            {
                return;
            }

            optionsBuilder.UseSqlServer(Web2Context.Configuration.DatabaseConfiguration.ConnectionString);
        }
    }
}
