﻿using System;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;

public sealed class ProposalNotFoundException : InvalidOperationException
{
    public ProposalNotFoundException(ProposalId proposalId) :
        base($"Proposal: {proposalId} not found.")
    {
    }
}
