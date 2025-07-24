namespace EventManagement.Api
{
    public static class StartupHelpers
    {
        public static IServiceCollection HandleCors(this IServiceCollection services, IConfiguration configuration)
        {
            var origins = configuration?.GetSection("Origins")?.Value?.Split(',').Where(o => !string.IsNullOrWhiteSpace(o)).ToArray();
            var allowAll = origins?.Length == 0 || origins!.Contains("*");

            return services.AddCors(options =>
            {
                if (allowAll)
                {
                    options.AddPolicy("CorsPolicy", builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("Content-Disposition"));
                }
                else
                {
                    options.AddPolicy("CorsPolicy", builder => builder
                        .WithOrigins(origins!)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("Content-Disposition"));
                }
            });
        }
    }
}
