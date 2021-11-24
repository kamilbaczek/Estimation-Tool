﻿using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Reminders")]

namespace Divstack.Company.Estimation.Tool.Reminders.Valuations;

using System.Reflection;
using DeadlineClose.Reminder;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

internal static class ValuationsModule
{
    private const string Configuration = "Configuration";
    private const string Reminder = "Reminder";

    internal static IServiceCollection AddValuations(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.Scan(scan => scan.FromAssemblyOf<ValuationsDeadlineCloseReminder>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith(Configuration)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.Scan(scan => scan.FromAssemblyOf<ValuationsDeadlineCloseReminder>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith(Reminder)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
