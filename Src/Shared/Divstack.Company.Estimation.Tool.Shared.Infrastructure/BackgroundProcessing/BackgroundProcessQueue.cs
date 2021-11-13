﻿namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.BackgroundProcessing;

using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abstractions.BackgroundProcessing;
using Hangfire;

internal sealed class BackgroundProcessQueue : IBackgroundProcessQueue
{
    public void Enqueue(Expression<Func<Task>> methodCall)
    {
        BackgroundJob.Enqueue(methodCall);
    }
}
