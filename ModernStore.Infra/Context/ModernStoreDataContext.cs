using ModernStore.Domain.Entities;
using ModernStore.Infra.Mappings;
using System.Data.Entity;

namespace ModernStore.Infra.Context
{
    public class ModernStoreDataContext: DbContext
    {
        private const string ModernStoreConnectionString = @"Server=localhost\SQLEXPRESS;Database=modernStore;Trusted_Connection=True";
        
        public ModernStoreDataContext(): base(ModernStoreConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderItemMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
