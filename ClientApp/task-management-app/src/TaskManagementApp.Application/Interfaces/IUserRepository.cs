using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Application.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<List<User>> GetFilteredUsersAsync(
            string? searchTerm,
            int page,
            int pageSize,
            CancellationToken cancellationToken = default);
    }
}
