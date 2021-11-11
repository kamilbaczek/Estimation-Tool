﻿using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Events;
using FluentAssertions;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Assertions;

internal static class AssertValuationEvents
{
    internal static void AssertIsCorrect(this ValuationRequestedDomainEvent domainEvent)
    {
        domainEvent.Should().NotBeNull();
        domainEvent.ValuationId.Value.Should().NotBeEmpty();
    }

    internal static void AssertIsCorrect(this ProposalSuggestedDomainEvent domainEvent, Money money,
        EmployeeId employee)
    {
        domainEvent.Should().NotBeNull();
        domainEvent.Value.Should().Be(money);
        domainEvent.ProposalId.Should().NotBeNull();
        domainEvent.ProposedBy.Should().Be(employee);
    }

    internal static void AssertIsCorrect(this ProposalApprovedDomainEvent domainEvent,
        EmployeeId employeeId,
        ProposalId proposalId)
    {
        domainEvent.Should().NotBeNull();
        domainEvent.SuggestedBy.Should().Be(employeeId);
        domainEvent.ProposalId.Should().Be(proposalId);
    }

    internal static void AssertIsCorrect(this ProposalRejectedDomainEvent domainEvent,
        ProposalId proposalId,
        ValuationId valuationId)
    {
        domainEvent.Should().NotBeNull();
        domainEvent.ProposalId.Should().Be(proposalId);
        domainEvent.ValuationId.Should().Be(valuationId);
    }

    internal static void AssertIsCorrect(this ValuationCompletedDomainEvent domainEvent,
        EmployeeId closedBy,
        ValuationId valuationId)
    {
        domainEvent.Should().NotBeNull();
        domainEvent.ClosedBy.Should().Be(closedBy);
        domainEvent.ValuationId.Should().Be(valuationId);
    }
}
