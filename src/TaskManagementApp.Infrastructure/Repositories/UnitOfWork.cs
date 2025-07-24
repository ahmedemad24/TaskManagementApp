using TaskManagementApp.Application.Interfaces;
using TaskManagementApp.Application.Interfaces.Persistence;
using TaskManagementApp.Infrastructure.Persistence;

namespace TaskManagementApp.Infrastructure.Repositories
{
    public class UnitOfWork(
           AppDbContext context,
           ITaskRepository taskRepository,
           IUserRepository userRepository
       ) : IUnitOfWork
    {
        public ITaskRepository Tasks => taskRepository;
        public IUserRepository Users => userRepository;

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
