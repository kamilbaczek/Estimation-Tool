﻿using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Persistance.DataAccess;
using MongoDB.Driver;

namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Repositories;

internal sealed class ValuationsRepository : IValuationsRepository
{
    private readonly IValuationsContext _valuationsContext;

    public ValuationsRepository(IValuationsContext valuationsContext)
    {
        _valuationsContext = valuationsContext;
    }

    public async Task<Valuation> GetAsync(ValuationId valuationId, CancellationToken cancellationToken = default)
    {
        return await _valuationsContext.Valuations
            .Find(valuation => valuation.Id.Value == valuationId.Value)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task AddAsync(Valuation valuation, CancellationToken cancellationToken = default)
    {
        await _valuationsContext.Valuations.InsertOneAsync(valuation, cancellationToken: cancellationToken);
    }

    public async Task CommitAsync(Valuation updatedValuation, CancellationToken cancellationToken = default)
    {
        await _valuationsContext.Valuations.ReplaceOneAsync(valuation => valuation.Id == updatedValuation.Id,
            updatedValuation, cancellationToken: cancellationToken);
    }
}
