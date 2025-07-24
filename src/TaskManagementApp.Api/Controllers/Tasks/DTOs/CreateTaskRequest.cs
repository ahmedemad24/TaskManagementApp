using TaskManagementApp.Domain.Enums;

namespace TaskManagementApp.Api.Controllers.Tasks.DTOs
{
    /// <summary>
    /// Represents the request payload for creating a task.
    /// </summary>
    public class CreateTaskRequest
    {
        /// <summary>
        /// Title of the task.
        /// </summary>
        public string Title { get; set; } = default!;

        /// <summary>
        /// Description of the task (optional).
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Due date of the task.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the task (e.g., Pending, InProgress, Completed).
        /// </summary>
        public Domain.Enums.TaskStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the priority level of the task (e.g., Low, Medium, High).
        /// </summary>
        public TaskPriority Priority { get; set; }

        /// <summary>
        /// The ID of the user assigned to this task.
        /// </summary>
        public Guid AssignedUserId { get; set; }
    }
}
