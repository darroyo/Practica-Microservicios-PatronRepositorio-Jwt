using Microsoft.EntityFrameworkCore;

namespace PatronRepositorio.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hamburguesa> Hamburguesas { get; set; }
        public DbSet<Alita> Alitas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hamburguesa>().ToTable("Hamburguesa");
            modelBuilder.Entity<Alita>().ToTable("Alita");
        }
    }
}
