using TaskManagementApp.Application.Common;

namespace TaskManagementApp.Api.Controllers.Tasks.DTOs
{
    /// <summary>
    /// Represents the search and pagination request for tasks.
    /// </summary>
    public class SearchTasksRequest : BaseSearchRequest
    {
        /// <summary>
        /// Optional user ID to filter tasks assigned to a specific user.
        /// </summary>
        public Guid? AssignedUserId { get; set; }

        /// <summary>
        /// Optional status to filter tasks by status.
        /// </summary>
        public Domain.Enums.TaskStatus? Status { get; set; }
    }
}
