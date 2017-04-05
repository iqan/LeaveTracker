using System.Configuration;
using System.Data.Entity;
using LeaveTracker.Models;

namespace LeaveTracker.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base()
        {
            Database.Connection.ConnectionString =
                string.Format(
                    ConfigurationManager.ConnectionStrings["iqanstestdb1"].ConnectionString, "iqan", "London11"
                    );

            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<LeaveDetails> Leaves { get; set; }
    }
}