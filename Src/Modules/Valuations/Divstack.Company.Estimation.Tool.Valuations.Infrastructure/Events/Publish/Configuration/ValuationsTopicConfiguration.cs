﻿namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Events.Publish.Configuration;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;

internal sealed class ValuationsTopicConfiguration : IValuationsTopicConfiguration
{
    private readonly IConfiguration _configuration;
    private const string Valuations = "Valuations";
    public ValuationsTopicConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    private const string ValuationsTopicKey = $"{Valuations}:{nameof(TopicName)}";

    public string TopicName => _configuration.GetValue<string>(Guard.Against.NullOrEmpty(ValuationsTopicKey, nameof(TopicName)));
}