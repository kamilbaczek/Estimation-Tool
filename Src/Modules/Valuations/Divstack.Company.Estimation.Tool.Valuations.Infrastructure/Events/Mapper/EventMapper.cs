﻿using System.Collections.Generic;
using System.Linq;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;
using Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

namespace Divstack.Company.Estimation.Tool.Estimations.Infrastructure.Events.Mapper;

internal sealed class EventMapper : IEventMapper
{
    public IReadOnlyCollection<IntegrationEvent> Map(IReadOnlyCollection<IDomainEvent> events)
    {
        return events.Select(Map).ToList();
    }

    private static IntegrationEvent Map(IDomainEvent @event)
    {
        return @event switch
        {
            ProposalApprovedDomainEvent domainEvent =>
                new ProposalApproved(domainEvent.ValuationId.Value,
                    domainEvent.ProposalId.Value,
                    domainEvent.SuggestedBy.Value,
                    domainEvent.Value.Currency,
                    domainEvent.Value.Value),
            ProposalCancelledDomainEvent domainEvent =>
                new ProposalCancelled(domainEvent.CancelledBy.Value,
                    domainEvent.ProposalId.Value,
                    domainEvent.ValuationId.Value),
            ProposalRejectedDomainEvent domainEvent =>
                new ProposalRejected(
                    domainEvent.ValuationId.Value,
                    domainEvent.ProposalId.Value,
                    domainEvent.Value.Value,
                    domainEvent.Value.Currency),
            ProposalSuggestedDomainEvent domainEvent =>
                new ProposalSuggested(
                    domainEvent.ValuationId.Value,
                    domainEvent.ProposalId.Value,
                    domainEvent.InquiryId.Value,
                    domainEvent.Value.Value,
                    domainEvent.Value.Currency,
                    domainEvent.Description.Message),
            ValuationRequestedDomainEvent domainEvent =>
                new ValuationRequested(
                    domainEvent.InquiryId.Value,
                    domainEvent.ValuationId.Value,
                    domainEvent.DeadlineDate.Date),
            ValuationCompletedDomainEvent domainEvent =>
                new ValuationCompleted(
                    domainEvent.InquiryId.Value,
                    domainEvent.ValuationId.Value,
                    domainEvent.Price.Value,
                    domainEvent.Price.Currency),
            _ => null
        };
    }
}
