﻿namespace Divstack.Company.Estimation.Tool.Valuations.Application.Common.Interfaces;

using System.Collections.Generic;
using Shared.DDD.BuildingBlocks;

public interface IIntegrationEventPublisher
{
    Task PublishAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken = default);
}
