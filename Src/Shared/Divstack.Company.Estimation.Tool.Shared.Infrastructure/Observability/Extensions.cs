﻿namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Observability;

using Azure.Telemetry;
using Microsoft.ApplicationInsights.Extensibility;

internal static class Extensions
{
    internal static IServiceCollection AddObservability(this IServiceCollection services)
    {
        services.AzureApplicationInsights();

        return services;
    }
}
