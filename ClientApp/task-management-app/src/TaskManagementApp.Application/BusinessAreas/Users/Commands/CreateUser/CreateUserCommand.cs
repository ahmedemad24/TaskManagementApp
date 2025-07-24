using MediatR;
using TaskManagementApp.Application.Common;

namespace TaskManagementApp.Application.BusinessAreas.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Result<Guid>>
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
