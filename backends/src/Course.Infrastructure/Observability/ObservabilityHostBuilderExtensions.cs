using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Hosting
{
    public static class ObservabilityHostBuilderExtensions
    {
        public static IHostBuilder AddObservability(this IHostBuilder builder) =>
            builder
                .AddApplicationInsights()
                .AddSerilog();

        }
}
