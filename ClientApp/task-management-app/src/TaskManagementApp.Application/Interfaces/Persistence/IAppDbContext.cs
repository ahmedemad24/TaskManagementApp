using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Application.Interfaces.Persistence
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<TaskItem> TaskItems { get; set; }

        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
