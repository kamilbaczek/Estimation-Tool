﻿namespace Divstack.Company.Estimation.Tool.Priorities.Priorities.Commands.Define;

using Common.Interfaces;
using Domain;
using Domain.Deadlines;
using Inquiries.Application.Common.Contracts;
using Inquiries.Application.Inquiries.Queries.GetClient;
using MediatR;
using Valuations.IntegrationsEvents.ExternalEvents;

internal sealed class DefinePrioritiesEventHandler : INotificationHandler<ValuationRequested>
{
    private readonly IDeadlinesConfiguration _deadlinesConfiguration;
    private readonly IInquiriesModule _inquiryModule;
    private readonly IIntegrationEventPublisher _integrationEventPublisher;
    private readonly IPrioritiesRepository _prioritiesRepository;

    public DefinePrioritiesEventHandler(IPrioritiesRepository prioritiesRepository,
        IIntegrationEventPublisher integrationEventPublisher,
        IDeadlinesConfiguration deadlinesConfiguration,
        IInquiriesModule inquiryModule)
    {
        _prioritiesRepository = prioritiesRepository;
        _integrationEventPublisher = integrationEventPublisher;
        _deadlinesConfiguration = deadlinesConfiguration;
        _inquiryModule = inquiryModule;
    }

    public async Task Handle(ValuationRequested notification, CancellationToken cancellationToken)
    {
        var deadline = Deadline.Create(_deadlinesConfiguration);
        var companySize = await GetCompanySize(notification.InquiryId);
        var valuationId = ValuationId.Create(notification.ValuationId);
        var inquiryId = InquiryId.Create(notification.InquiryId);

        var priority = Priority.Define(valuationId, inquiryId, companySize, deadline);

        await _prioritiesRepository.AddAsync(priority, cancellationToken);
        await _integrationEventPublisher.PublishAsync(priority.DomainEvents, cancellationToken);
    }

    private async Task<int?> GetCompanySize(Guid inquiryId)
    {
        var inquiryQuery = new GetInquiryClientQuery(inquiryId);
        var client = await _inquiryModule.ExecuteQueryAsync(inquiryQuery);

        return client.CompanySize;
    }
}