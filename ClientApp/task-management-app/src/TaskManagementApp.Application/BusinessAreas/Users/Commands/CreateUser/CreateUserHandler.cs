using MediatR;
using TaskManagementApp.Application.Common;
using TaskManagementApp.Application.Interfaces.Persistence;
using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Application.BusinessAreas.Users.Commands.CreateUser
{
    public class CreateUserHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateUserCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await unitOfWork.Users.GetByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return Result.Failure<Guid>("User with this email already exists.");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = hashedPassword
            };

            await unitOfWork.Users.AddAsync(user);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success(user.Id);
        }
    }
}
