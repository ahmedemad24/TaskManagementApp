using MediatR;
using TaskManagementApp.Application.Common;
using TaskManagementApp.Domain.Enums;

namespace TaskManagementApp.Application.BusinessAreas.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<Result<Guid>>
    {
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public Domain.Enums.TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public Guid AssignedUserId { get; set; }
    }
}
