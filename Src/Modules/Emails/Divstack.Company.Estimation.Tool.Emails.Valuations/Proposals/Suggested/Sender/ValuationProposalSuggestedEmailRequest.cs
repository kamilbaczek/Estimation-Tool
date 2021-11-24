﻿namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested.Sender;

using System;

internal record ValuationProposalSuggestedEmailRequest(
    Guid ValuationId,
    Guid ProposalId,
    Guid InquiryId,
    string FullName,
    string Email,
    decimal? Value,
    string Currency,
    string Description);
