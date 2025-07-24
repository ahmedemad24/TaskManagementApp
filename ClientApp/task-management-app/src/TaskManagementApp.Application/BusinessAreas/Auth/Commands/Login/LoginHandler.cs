using MediatR;
using TaskManagementApp.Application.Common;
using TaskManagementApp.Application.Services;

namespace TaskManagementApp.Application.BusinessAreas.Auth.Commands.Login
{
    public class LoginHandler(IAuthService authService) : IRequestHandler<LoginCommand, Result<string?>>
    {
        public async Task<Result<string?>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var auth = await authService.AuthenticateAsync(request.Email, request.Password);

            if (!string.IsNullOrEmpty(auth))
            {
                return Result.Success(auth);
            }

            return Result.Failure<string?>("Invalid credintials!");
        }
    }
}
