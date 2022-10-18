using Microsoft.EntityFrameworkCore;

namespace ProductManager.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<New> News { get; set; }
        public DbSet<TypeNew> TypeNew {get; set;}
        public object TypeNews { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<New>()
                .HasOne(p => p.TypeNew)
                .WithMany(p =>p.News)
                .HasForeignKey(p =>p.TypeNewId);
            base.OnModelCreating(modelBuilder);
        }
    }
}