using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Infrastructure.Logging
{

    public class LoggerFactory
    {
        private readonly LoggingConfig _config;

        public LoggerFactory(LoggingConfig config)
        {
            _config = config;

            // Ensure log directory exists
            var logDirectory = Path.GetDirectoryName(_config.FilePath);
            if (!string.IsNullOrEmpty(logDirectory) && !Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
        }

        public ILogger CreateSystemLogger()
        {
            var logLevel = ParseLogLevel(_config.Level);

            return new LoggerConfiguration()
                .MinimumLevel.Is(logLevel)
                .WriteTo.Console()
                .WriteTo.File(_config.FilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public ILogger CreateEventStreamLogger()
        {
            return new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(_config.EventStreamFilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public ILogger CreateAgentExecutionLogger()
        {
            return new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(_config.AgentExecutionFilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        private LogEventLevel ParseLogLevel(string level)
        {
            return level.ToLower() switch
            {
                "verbose" => LogEventLevel.Verbose,
                "debug" => LogEventLevel.Debug,
                "information" => LogEventLevel.Information,
                "warning" => LogEventLevel.Warning,
                "error" => LogEventLevel.Error,
                "fatal" => LogEventLevel.Fatal,
                _ => LogEventLevel.Information
            };
        }
    }
}
