using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AFS.Payment.DataAccess
{
    public class PaymentContext : DbContext
    {
        public PaymentContext() : base("name=PaymentDbConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PaymentContext>());
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
