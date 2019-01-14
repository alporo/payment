using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AFS.Payment.Data
{
    public class PaymentContext : DbContext
    {
        public PaymentContext() : base("name=PaymentDbConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PaymentContext>());
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
