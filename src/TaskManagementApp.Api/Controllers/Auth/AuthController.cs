using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Api.Controllers.Auth.DTOs;
using TaskManagementApp.Api.Controllers.Auth.Mappers;
using TaskManagementApp.Application.Common;

namespace TaskManagementApp.Api.Controllers.Auth
{
    /// <summary>
    /// API controller for managing auth.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Login.
        /// </summary>
        /// <param name="request">The login request.</param>
        /// <returns>The JWT of this login.</returns>
        [HttpPost]
        public async Task<Result<string?>> Login([FromBody] LoginRequest request)
        {
            var command = request.ToCommand();
            Result<string?> result = await mediator.Send(command);
            return result;
        }
    }
}
