using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Application.BusinessAreas.Tasks.Queries.GetTasksWithPagination;
using TaskManagementApp.Application.Interfaces;
using TaskManagementApp.Domain.Entities;
using TaskManagementApp.Infrastructure.Persistence;

namespace TaskManagementApp.Infrastructure.Repositories
{
    public class TaskRepository : BaseRepository<TaskItem>, ITaskRepository
    {
        private new readonly AppDbContext _context;
        public TaskRepository(AppDbContext context) : base(context) { _context = context; }

        public async Task<List<TaskItemResult>> GetFilteredTasksAsync(
            Guid? assignedUserId,
            Domain.Enums.TaskStatus? status,
            int page,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            var query = _context.TaskItems.Include(t => t.AssignedUser).AsQueryable();

            if (assignedUserId.HasValue)
            {
                query = query.Where(t => t.AssignedUserId == assignedUserId.Value);
            }

            if (status.HasValue)
            {
                query = query.Where(t => t.Status == status.Value);
            }

            var result = await query
            .Select(t => new TaskItemResult
            {
                Id = t.Id,
                Title = t.Title,
                Status = t.Status.ToString(),
                Priority = t.Priority.ToString(),
                DueDate = t.DueDate,
                AssignedUserId = t.AssignedUserId,
                AssignedUser = new AssignedUserItem
                {
                    FullName = t!.AssignedUser!.FullName ?? "",
                    Email = t.AssignedUser.Email
                }
            })
            .ToListAsync(cancellationToken);

            return result;
        }
    }
}
