﻿namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

public sealed class PaymentSecret : ValueObject
{
    private PaymentSecret(string value)
    {
        Value = Guard.Against.NullOrEmpty(value, nameof(Payment));
    }
    public static PaymentSecret Of(string value)
    {
        return new PaymentSecret(value);
    }
    
    public string Value { get; init; }
}
