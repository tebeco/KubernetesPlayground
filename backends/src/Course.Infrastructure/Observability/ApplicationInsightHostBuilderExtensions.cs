using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Hosting
{
    public static class ApplicationInsightsHostBuilderExtensions
    {
        public static IHostBuilder AddApplicationInsights(this IHostBuilder builder) =>
            builder.ConfigureServices((host, services) => services.AddApplicationInsightsTelemetry());
    }
}
