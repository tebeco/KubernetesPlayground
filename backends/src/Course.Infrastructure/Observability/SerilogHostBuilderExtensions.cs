using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Hosting
{
    public static class ApplicationInsightHostBuilderExtensions
    {
        public static IHostBuilder AddSerilog(this IHostBuilder builder)
        {
            return builder.UseSerilog((hostBuilderContext, serviceProvider, loggerConfiguration) =>
            {
                loggerConfiguration.ConfigureLoggerConfiguration(serviceProvider);
            });
        }

        public static LoggerConfiguration ConfigureLoggerConfiguration(this LoggerConfiguration loggerConfiguration, IServiceProvider serviceProvider)
        {
            var env = serviceProvider.GetRequiredService<IHostEnvironment>();

            loggerConfiguration.MinimumLevel.Verbose();

            if (!env.IsProduction())
            {
                loggerConfiguration.WriteTo.Console();
            }

            loggerConfiguration
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", env.ApplicationName)
                .Enrich.WithProperty("Environment", env.EnvironmentName)
                .WriteTo.ApplicationInsights(
                    serviceProvider.GetRequiredService<TelemetryConfiguration>(),
                    TelemetryConverter.Traces)
                ;

            return loggerConfiguration;
        }
    }
}
