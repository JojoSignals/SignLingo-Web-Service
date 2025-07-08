using System;
using System.Threading;
using System.Threading.Tasks;
using Cronos;
using Domain.UserStats.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infrastructure.UserStats.CronJobs
{
    public class IncreaseLivesJob : BackgroundService
    {
        private readonly CronExpression _cronExpression;
        private readonly TimeZoneInfo _timeZone;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<IncreaseLivesJob> _logger;

        public IncreaseLivesJob(
            IServiceScopeFactory scopeFactory,
            ILogger<IncreaseLivesJob> logger)
        {
            _cronExpression = CronExpression.Parse("* * * * *"); // cada 10 minutos
            _timeZone = TimeZoneInfo.Local;
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("IncreaseLivesJob iniciado.");

            while (!stoppingToken.IsCancellationRequested)
            {
                var next = _cronExpression.GetNextOccurrence(DateTimeOffset.UtcNow, _timeZone);

                if (next.HasValue)
                {
                    var delay = next.Value - DateTimeOffset.UtcNow;

                    if (delay.TotalMilliseconds > 0)
                    {
                        try
                        {
                            await Task.Delay(delay, stoppingToken);
                        }
                        catch (TaskCanceledException)
                        {
                            break;
                        }
                    }

                    using var scope = _scopeFactory.CreateScope();
                    var commandService = scope.ServiceProvider.GetRequiredService<IUserStatsCommandService>();

                    try
                    {
                        await commandService.IncreaseLivesAsync(stoppingToken);
                        _logger.LogInformation("IncreaseLivesJob ejecutado a las {time}", DateTime.UtcNow);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error al ejecutar IncreaseLivesJob");
                    }
                }
                else
                {
                    _logger.LogWarning("No se pudo calcular la próxima ejecución del cron.");
                    break;
                }
            }
        }
    }
}
