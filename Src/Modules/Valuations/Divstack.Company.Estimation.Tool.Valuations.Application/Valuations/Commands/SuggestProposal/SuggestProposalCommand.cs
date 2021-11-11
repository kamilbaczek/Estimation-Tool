﻿using System;
using Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.SuggestProposal;

public sealed class SuggestProposalCommand : ICommand
{
    public string Currency { get; set; }
    public decimal Value { get; set; }
    public string Description { get; set; }
    public Guid ValuationId { get; set; }
}
