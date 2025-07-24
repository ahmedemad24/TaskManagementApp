using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Application.Interfaces.Persistence;
using TaskManagementApp.Application.Services;

namespace TaskManagementApp.Infrastructure.Services
{
    public class AuthService(IAppDbContext context, IJwtTokenGenerator jwtTokenGenerator) : IAuthService
    {
        public async Task<string?> AuthenticateAsync(string email, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return null;

            var isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            if (!isValid) return null;

            return jwtTokenGenerator.GenerateToken(user);
        }
    }
}
