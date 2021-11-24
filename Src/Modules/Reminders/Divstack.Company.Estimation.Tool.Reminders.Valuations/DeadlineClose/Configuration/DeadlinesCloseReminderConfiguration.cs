﻿namespace Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Configuration;

using Microsoft.Extensions.Configuration;
using Tool.Valuations.Domain.Valuations;

internal sealed class DeadlinesCloseReminderConfiguration : IDeadlinesCloseReminderConfiguration
{
    private readonly IConfigurationSection _configuration;

    public DeadlinesCloseReminderConfiguration(IConfiguration configuration)
    {
        var sectionKey = $"Reminders:{nameof(Valuation)}";
        _configuration = configuration.GetSection(sectionKey);
    }

    public int DaysBeforeDeadline => _configuration.GetValue<int>(nameof(DaysBeforeDeadline));
}
