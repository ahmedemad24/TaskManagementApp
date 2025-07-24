using TaskManagementApp.Domain.Enums;

namespace TaskManagementApp.Api.Controllers.Tasks.DTOs
{
    /// <summary>
    /// Represents a request to update an existing task.
    /// </summary>
    public class UpdateTaskRequest
    {
        /// <summary>
        /// Gets or sets the title of the task.
        /// </summary>
        public string Title { get; set; } = default!;

        /// <summary>
        /// Gets or sets the optional description of the task.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the due date of the task.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user to whom the task is assigned.
        /// </summary>
        public Guid AssignedUserId { get; set; }

        /// <summary>
        /// Gets or sets the status of the task (e.g., Pending, InProgress, Completed).
        /// </summary>
        public Domain.Enums.TaskStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the priority level of the task (e.g., Low, Medium, High).
        /// </summary>
        public TaskPriority Priority { get; set; }
    }

}
