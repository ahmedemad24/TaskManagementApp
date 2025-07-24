using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TaskManagementApp.Worker.Services
{
    internal sealed class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logWorkerRunning(_logger, DateTimeOffset.Now, null);
                await Task.Delay(1000, stoppingToken);
            }
        }

        private static readonly Action<ILogger, DateTimeOffset, Exception?> _logWorkerRunning =
        LoggerMessage.Define<DateTimeOffset>(
            LogLevel.Information,
            new EventId(1, nameof(Worker)),
            "Worker running at: {Time}");
    }
}
