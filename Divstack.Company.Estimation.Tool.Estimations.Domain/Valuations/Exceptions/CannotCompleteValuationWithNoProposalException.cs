﻿using System;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Exceptions
{
    public sealed class CannotCompleteValuationWithNoProposalException : InvalidOperationException
    {
        public CannotCompleteValuationWithNoProposalException(ValuationId valuationId) :
            base($"Cannot complete Valuation {valuationId} with no proposals")
        {}
    }
}
