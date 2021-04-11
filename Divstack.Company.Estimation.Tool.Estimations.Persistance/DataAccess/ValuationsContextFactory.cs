﻿using Microsoft.EntityFrameworkCore;

namespace Divstack.Company.Estimation.Tool.Estimations.Persistance.DataAccess
{
    internal sealed class ValuationsContextFactory : DesignTimeDbContextFactoryBase<ValuationsContext>
    {
        protected override ValuationsContext CreateNewInstance(DbContextOptions<ValuationsContext> options)
        {
            return new ValuationsContext(options);
        }
    }
}
