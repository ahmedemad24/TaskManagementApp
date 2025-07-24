using Microsoft.Extensions.Configuration;

namespace TaskManagementApp.Application.Models
{
    public sealed class TaskManagementConfiguration
    {
        public string ConnectionString { get; set; } = null!;
        public JwtSettings Jwt { get; set; } = null!;
        public int TokenExpiryInMinutes { get; set; } = 60;
        public bool EnableBackgroundJobs { get; set; } = true;

        public static TaskManagementConfiguration CreateFrom(IConfiguration configuration)
        {
            TaskManagementConfiguration? config = new TaskManagementConfiguration();
            configuration?.GetSection("TaskManagementConfiguration").Bind(config);

            if (string.IsNullOrWhiteSpace(config.ConnectionString))
                throw new ArgumentException("ConnectionString is required.");

            if (string.IsNullOrWhiteSpace(config.Jwt?.Key))
                throw new ArgumentException("Jwt.Key is required.");

            if (config.TokenExpiryInMinutes <= 0)
                throw new ArgumentException("TokenExpiryInMinutes must be positive.");

            return config;
        }
    }

    public sealed class JwtSettings
    {
        public string Key { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
    }
}
