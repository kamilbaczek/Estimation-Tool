﻿namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Subscribe.Logger;

using EventTypes;
using global::Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;

internal sealed class SubscriberLogger : ISubscriberLogger
{
    private readonly ILogger<SubscriberLogger> _logger;
    public SubscriberLogger(ILogger<SubscriberLogger> logger)
    {
        _logger = logger;
    }
    public void LogProcessing(ServiceBusReceivedMessage message, EventType receivedMessageEventType)
    {
        var processingLogInformation = $"Processing: '{message.MessageId}' type of {receivedMessageEventType.Value}";
        _logger.LogInformation(processingLogInformation);
    }

    public void LogError(Exception exception)
    {
        var processingError = $"Error during message processing message: '{exception.Message}'";
        _logger.LogError(processingError);
    }

}