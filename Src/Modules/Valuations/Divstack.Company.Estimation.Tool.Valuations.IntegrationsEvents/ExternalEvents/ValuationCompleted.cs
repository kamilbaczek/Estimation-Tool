﻿namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

using System;
using Shared.DDD.BuildingBlocks;

public record ValuationCompleted(
    Guid InquiryId,
    Guid ValuationId,
    decimal? AmountToPayValue,
    string AmountToPayCurrency) : IntegrationEvent;
