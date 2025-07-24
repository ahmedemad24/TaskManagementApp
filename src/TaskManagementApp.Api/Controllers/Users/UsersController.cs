using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Api.Controllers.Users.DTOs;
using TaskManagementApp.Api.Controllers.Users.Mappers;
using TaskManagementApp.Application.Common;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Api.Controllers.Users
{
    /// <summary>
    /// API controller for managing tasks.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="request">The task creation request.</param>
        /// <returns>The ID of the newly created task.</returns>
        [HttpPost]
        public async Task<Result<Guid>> Create([FromBody] CreateUserRequest request)
        {
            var command = request.ToCommand();
            Result<Guid> result = await mediator.Send(command);
            return result;
        }

        /// <summary>
        /// Retrieves a paginated and filtered list of users.
        /// </summary>
        /// <param name="request">The filter and pagination criteria.</param>
        /// <returns>A paginated list of users.</returns>
        [HttpGet("search")]
        public async Task<Result<List<User>>> Search([FromQuery] SearchUserRequest request)
        {
            var query = request.ToQuery();
            Result<List<User>> result = await mediator.Send(query);
            return result;
        }
    }
}
