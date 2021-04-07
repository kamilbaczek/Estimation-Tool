﻿using System;
using System.Collections.Generic;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Events;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks.CompanyName.MyMeetings.BuildingBlocks.Domain;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations
{
    public sealed class Enquiry : Entity
    {
        private Enquiry(
            Valuation valuation,
            IReadOnlyList<ProductId> productsIds,
            Client client)
        {
            Valuation = valuation ?? throw new ArgumentNullException(nameof(valuation));
            ProductsIds = productsIds ?? throw new ArgumentNullException(nameof(productsIds));
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        internal static Enquiry Create(
            Valuation valuation,
            IReadOnlyList<ProductId> productsIds,
            Client client)
        {
            return new (valuation, productsIds, client);
        }

        private Valuation Valuation  { get; set; }
        private IReadOnlyList<ProductId> ProductsIds { get; set; }
        private Client Client { get; set; }

    }
}
