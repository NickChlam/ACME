using Microsoft.EntityFrameworkCore;
using ACM.BL;

namespace ACM.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        // public DataContext(DbContextOptions options) : base(options) { Database.Migrate(); }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

         public DbSet<Customer> Customers {get; set; }
         public DbSet<Address> Address {get; set;}
         public DbSet<Product> Products {get; set;}
         public DbSet<Order> Orders {get; set;}
         public DbSet<OrderItem> OrderItems {get; set;}

         

       

    }
}