﻿using System;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Assertions;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations.Common;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;
using Xunit;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Tests.Valuations
{
    public class CompleteValuationTests : BaseValuationTest
    {
        [Fact]
        public async Task Given_Complete_When_ValuationHasAtLastOnceProposalWithDecision_Then_ValuationIsCompleted()
        {
            var employee = new EmployeeId(Guid.NewGuid());
            var valuation = await RequestFakeValuation();
            var proposalId = SuggestFakeProposal(valuation);
            valuation.ApproveProposal(proposalId);

            valuation.Complete(employee);

            var @event = GetPublishedEvent<ValuationCompletedEvent>(valuation);
            @event.AssertIsCorrect(employee, valuation.Id);
        }
    }
}