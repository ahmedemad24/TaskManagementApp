using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Application.Interfaces.Persistence;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder?.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
