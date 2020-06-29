using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using brain.entities;
namespace brain.data.DAL
{
    public class BrainContext : DbContext
    {
        public BrainContext() : base("BrainContext")
        {

        }

        public DbSet<AnalysisLog> AnalysisLog { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
