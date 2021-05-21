using Microsoft.EntityFrameworkCore;


namespace Web2_Backend.Model
{
    public class Web2Context : DbContext
    {
        public Web2Context() { }

        public Web2Context(DbContextOptions<Web2Context> context) : base(context) 
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Calls> Calls { get; set; }
        public DbSet<WorkingPlan> WorkingPlans { get; set; }
        public DbSet<Crew> Crews { get; set; }

        public DbSet<Cosumer> Cosumers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (optionsBuilder.IsConfigured) 
            {
                return;
            }

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-TJ9PUSD\SQLEXPRESS;Database=WEB2;Trusted_Connection=True;");
        }
    }
}
