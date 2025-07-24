using MediatR;
using TaskManagementApp.Application.Common;
using TaskManagementApp.Domain.Enums;

namespace TaskManagementApp.Application.BusinessAreas.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest<Result<bool>>
    {
        public Guid TaskId { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public Guid AssignedUserId { get; set; }
        public Domain.Enums.TaskStatus Status { get; set; } = Domain.Enums.TaskStatus.Pending;
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
    }
}
