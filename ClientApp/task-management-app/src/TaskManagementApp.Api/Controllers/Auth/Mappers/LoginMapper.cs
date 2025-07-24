
using TaskManagementApp.Api.Controllers.Auth.DTOs;
using TaskManagementApp.Application.BusinessAreas.Auth.Commands.Login;

namespace TaskManagementApp.Api.Controllers.Auth.Mappers
{
    /// <summary>
    /// Maps login DTOs to application layer commands.
    /// </summary>
    public static class LoginMapper
    {
        /// <summary>
        /// Maps <see cref="LoginRequest"/> to <see cref="LoginCommand"/>.
        /// </summary>
        public static LoginCommand ToCommand(this LoginRequest request)
        {
            return new LoginCommand(Email: request.Email, Password: request.Password);
        }
    }
}
