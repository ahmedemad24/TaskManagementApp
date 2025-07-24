using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Api.Controllers.Tasks.DTOs;
using TaskManagementApp.Api.Controllers.Tasks.Mappers;
using TaskManagementApp.Application.BusinessAreas.Tasks.Commands.DeleteTask;
using TaskManagementApp.Application.BusinessAreas.Tasks.Queries.GetTaskDetailsById;
using TaskManagementApp.Application.BusinessAreas.Tasks.Queries.GetTasksWithPagination;
using TaskManagementApp.Application.Common;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Api.Controllers.Tasks
{
    /// <summary>
    /// API controller for managing tasks.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="request">The task creation request.</param>
        /// <returns>The ID of the newly created task.</returns>
        [HttpPost]
        public async Task<Result<Guid>> Create([FromBody] CreateTaskRequest request)
        {
            var command = request.ToCommand();
            Result<Guid> result = await mediator.Send(command);
            return result;
        }

        /// <summary>
        /// Deletes a task by ID.
        /// </summary>
        /// <param name="id">The task ID to delete.</param>
        /// <returns>Boolean result indicating success.</returns>
        [HttpDelete("{id:guid}")]
        public async Task<Result<bool>> Delete(Guid id)
        {
            var command = new DeleteTaskCommand { TaskId = id };
            Result<bool> result = await mediator.Send(command);
            return result;
        }

        /// <summary>
        /// Updates an existing task.
        /// </summary>
        /// <param name="id">The task ID to update.</param>
        /// <param name="request">The update request payload.</param>
        /// <returns>Boolean result indicating success.</returns>
        [HttpPut("{id:guid}")]
        public async Task<Result<bool>> Update(Guid id, [FromBody] UpdateTaskRequest request)
        {
            var command = id.ToCommand(request);
            Result<bool> result = await mediator.Send(command);
            return result;
        }

        /// <summary>
        /// Retrieves a paginated and filtered list of tasks.
        /// </summary>
        /// <param name="request">The filter and pagination criteria.</param>
        /// <returns>A paginated list of tasks.</returns>
        [HttpGet("search")]
        public async Task<Result<List<TaskItemResultDto>>> Search([FromQuery] SearchTasksRequest request)
        {
            var query = request.ToQuery();
            Result<List<TaskItemResult>> result = await mediator.Send(query);
            return SearchTasksMapper.ToResultDto(result);
        }

        /// <summary>
        /// Retrieves a task by its ID.
        /// </summary>
        /// <param name="id">The ID of the task to retrieve.</param>
        /// <returns>The task if found, or a not found result.</returns>
        [HttpGet("{id:guid}")]
        public async Task<Result<TaskItem>> GetById(Guid id)
        {
            var query = new GetTaskDetailsByIdQuery { TaskId = id };
            Result<TaskItem> result = await mediator.Send(query);
            return result;
        }
    }
}
