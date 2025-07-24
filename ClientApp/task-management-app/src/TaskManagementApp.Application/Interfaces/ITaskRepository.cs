using TaskManagementApp.Application.BusinessAreas.Tasks.Queries.GetTasksWithPagination;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Application.Interfaces
{
    public interface ITaskRepository : IRepository<TaskItem>
    {
        Task<List<TaskItemResult>> GetFilteredTasksAsync(
        Guid? assignedUserId,
        Domain.Enums.TaskStatus? status,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default);
    }
}
