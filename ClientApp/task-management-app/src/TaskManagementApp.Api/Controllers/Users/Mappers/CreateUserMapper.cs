using TaskManagementApp.Api.Controllers.Users.DTOs;
using TaskManagementApp.Application.BusinessAreas.Users.Commands.CreateUser;

namespace TaskManagementApp.Api.Controllers.Users.Mappers
{
    /// <summary>
    /// Maps User DTOs to application layer commands.
    /// </summary>
    public static class CreateUserMapper
    {
        /// <summary>
        /// Maps <see cref="CreateUserRequest"/> to <see cref="CreateUserCommand"/>.
        /// </summary>
        public static CreateUserCommand ToCommand(this CreateUserRequest request)
        {
            return new CreateUserCommand
            {
                FullName = request.FullName,
                Email = request.Email,
                Password = request.Password
            };
        }
    }
}
