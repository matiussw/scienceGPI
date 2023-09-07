using Microsoft.EntityFrameworkCore;
using scienceGPI.shared.Entities;

namespace scienceGPI.API.Data
{
	public class DataContext : DbContext

	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Researcher> Researchers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Researcher>().HasKey(x => x.Cedula);
        }

    }
}

