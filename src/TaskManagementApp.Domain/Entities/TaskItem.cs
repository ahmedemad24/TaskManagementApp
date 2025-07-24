using TaskManagementApp.Domain.Enums;

namespace TaskManagementApp.Domain.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public Domain.Enums.TaskStatus Status { get; set; } = Domain.Enums.TaskStatus.Pending;
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
        public DateTime DueDate { get; set; }
        public Guid? AssignedUserId { get; set; }
        public User? AssignedUser { get; set; }
    }
}
