using Microsoft.EntityFrameworkCore;

namespace ProductManager.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderType> OrderType {get; set;}
        public object OrderTypes { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(p => p.OrderType)
                .WithMany(p =>p.Orders)
                .HasForeignKey(p =>p.OrderTypeId);
            base.OnModelCreating(modelBuilder);
        }
    }
}