using Clinical_Trial_Task_Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinical_Trial_Task_Manager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Study> Studies => Set<Study>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<TaskItem> TaskItems => Set<TaskItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique code for Patient
            modelBuilder.Entity<Patient>()
                .HasIndex(p => p.Code)
                .IsUnique();
        }
    }
}
