using System;

namespace brain.data.DAL
{
    public class BrainInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BrainContext>
    {
        protected override void Seed(BrainContext context)
        {
            //non-initial-values
        }
    }
}
