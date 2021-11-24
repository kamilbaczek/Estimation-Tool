﻿namespace Divstack.Company.Estimation.Tool.Valuations.Application.Common.Contracts;

using System.Threading.Tasks;

public interface IValuationsModule
{
    Task ExecuteCommandAsync(ICommand command);
    Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);
    Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
}
