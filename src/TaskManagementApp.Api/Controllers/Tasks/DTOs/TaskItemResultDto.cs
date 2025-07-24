namespace TaskManagementApp.Api.Controllers.Tasks.DTOs
{
    /// <summary>
    /// Represents the result of a task item returned from the API.
    /// </summary>
    public class TaskItemResultDto
    {
        /// <summary>
        /// The unique identifier of the task.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The title of the task.
        /// </summary>
        public string Title { get; set; } = default!;

        /// <summary>
        /// The status of the task (e.g., Pending, InProgress, Completed).
        /// </summary>
        public string Status { get; set; } = default!;

        /// <summary>
        /// The priority of the task (e.g., Low, Medium, High).
        /// </summary>
        public string Priority { get; set; } = default!;

        /// <summary>
        /// The due date of the task.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// The ID of the user to whom the task is assigned.
        /// </summary>
        public Guid? AssignedUserId { get; set; }

        /// <summary>
        /// The user details of the person to whom the task is assigned.
        /// </summary>
        public AssignedUserItemDto? AssignedUser { get; set; }
    }

    /// <summary>
    /// Represents a simplified user object containing user identity and contact details.
    /// </summary>
    public class AssignedUserItemDto
    {
        /// <summary>
        /// The full name of the user.
        /// </summary>
        public string FullName { get; set; } = default!;

        /// <summary>
        /// The email address of the user.
        /// </summary>
        public string Email { get; set; } = default!;
    }
}
