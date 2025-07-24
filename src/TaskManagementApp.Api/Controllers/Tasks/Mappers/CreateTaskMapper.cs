using TaskManagementApp.Api.Controllers.Tasks.DTOs;
using TaskManagementApp.Application.BusinessAreas.Tasks.Commands.CreateTask;

namespace TaskManagementApp.Api.Controllers.Tasks.Mappers
{
    /// <summary>
    /// Maps task-related DTOs to application layer commands.
    /// </summary>
    public static class CreateTaskMapper
    {
        /// <summary>
        /// Maps <see cref="CreateTaskRequest"/> to <see cref="CreateTaskCommand"/>.
        /// </summary>
        public static CreateTaskCommand ToCommand(this CreateTaskRequest request)
        {
            return new CreateTaskCommand
            {
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                Status = request.Status,
                Priority = request.Priority,
                AssignedUserId = request.AssignedUserId
            };
        }
    }
}
