using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder
{
    public static class ProbeEndpointBuilderExtensionMethod
    {
        public static IEndpointRouteBuilder MapProbes(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapLivenessProbe();
            endpoints.MapReadinessProbe();

            return endpoints;
        }

        public static IEndpointConventionBuilder MapLivenessProbe(this IEndpointRouteBuilder endpoints) =>
            endpoints.MapProbe("/probe/live");

        public static IEndpointConventionBuilder MapReadinessProbe(this IEndpointRouteBuilder endpoints) =>
            endpoints.MapProbe("/probe/ready");

        public static IEndpointConventionBuilder MapProbe(this IEndpointRouteBuilder endpoints, string path) =>
            endpoints.MapGet(path, context =>
            {
                context.Response.StatusCode = 200;

                return Task.CompletedTask;
            });
    }
}
