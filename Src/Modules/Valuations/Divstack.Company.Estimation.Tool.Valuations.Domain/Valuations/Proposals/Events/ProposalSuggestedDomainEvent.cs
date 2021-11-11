﻿using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;

public sealed class ProposalSuggestedDomainEvent : DomainEventBase
{
    internal ProposalSuggestedDomainEvent(
        EmployeeId proposedBy,
        ProposalId proposalId,
        Money value,
        ProposalDescription description,
        ValuationId valuationId,
        InquiryId inquiryId)
    {
        InquiryId = inquiryId;
        ProposedBy = proposedBy;
        Value = value;
        ProposalId = proposalId;
        Description = description;
        ValuationId = valuationId;
    }

    public InquiryId InquiryId { get; }
    public ProposalId ProposalId { get; }
    public EmployeeId ProposedBy { get; }
    public Money Value { get; }
    public ProposalDescription Description { get; }
    public ValuationId ValuationId { get; }
}
