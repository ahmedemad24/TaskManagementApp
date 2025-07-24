using TaskManagementApp.Domain.Entities;

namespace TaskManagementApp.Application.Services
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(User user);
    }
}
