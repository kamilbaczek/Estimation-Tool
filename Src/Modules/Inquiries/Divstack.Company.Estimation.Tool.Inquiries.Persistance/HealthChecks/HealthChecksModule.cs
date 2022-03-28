﻿namespace Divstack.Company.Estimation.Tool.Inquiries.Persistance.HealthChecks;

using Microsoft.Extensions.DependencyInjection;

internal static class HealthChecksModule
{
    private const string DatabaseName = "Inquiries Database";
    private const string Inquiries = "Inquiries";
    private const string Database = "Database";

    internal static IServiceCollection AddPersistanceHealthChecks(this IServiceCollection services, string connectionString)
    {
        services.AddHealthChecks().AddMongoDb(connectionString, DatabaseName, null, new[] { Inquiries, Database }, null);

        return services;
    }
}
