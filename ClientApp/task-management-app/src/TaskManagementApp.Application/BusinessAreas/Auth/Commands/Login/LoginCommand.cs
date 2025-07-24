using MediatR;
using TaskManagementApp.Application.Common;

namespace TaskManagementApp.Application.BusinessAreas.Auth.Commands.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<Result<string?>>;
}
