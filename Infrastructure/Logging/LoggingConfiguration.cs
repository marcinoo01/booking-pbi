using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

namespace Booking.Infrastructure.Logging
{
    public static class LoggingConfiguration
    {
        public static LoggerConfiguration Configure(LoggerConfiguration config, IConfiguration cfg)
        {
            return config
                .MinimumLevel.Is(LogEventLevel.Information)
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.File("Logs/error-.txt", restrictedToMinimumLevel: LogEventLevel.Error, rollingInterval: RollingInterval.Day);
        }
    }
}