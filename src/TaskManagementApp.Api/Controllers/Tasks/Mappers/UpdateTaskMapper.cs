using TaskManagementApp.Api.Controllers.Tasks.DTOs;
using TaskManagementApp.Application.BusinessAreas.Tasks.Commands.UpdateTask;

namespace TaskManagementApp.Api.Controllers.Tasks.Mappers
{
    /// <summary>
    /// Provides mapping functionality from <see cref="UpdateTaskRequest"/> to <see cref="UpdateTaskCommand"/>.
    /// </summary>
    public static class UpdateTaskMapper
    {
        /// <summary>
        /// Maps <see cref="UpdateTaskRequest"/> to <see cref="UpdateTaskCommand"/>.
        /// </summary>
        public static UpdateTaskCommand ToCommand(this Guid TaskId, UpdateTaskRequest request)
        {
            return new UpdateTaskCommand
            {
                TaskId = TaskId,
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                AssignedUserId = request.AssignedUserId,
                Status = request.Status,
                Priority = request.Priority
            };
        }
    }
}
