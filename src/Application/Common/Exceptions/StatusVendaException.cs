namespace tech_test_payment_api.Application.Common.Exceptions;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Domain.Enum;
using tech_test_payment_api.Application.Common.Entities;

[Serializable]
[ExcludeFromCodeCoverage]
public class StatusVendaException : Exception
{
    public StatusVendaException(string message)
        : base(message)
    {
    }

    protected StatusVendaException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }

    /// <summary>Throws an <see cref="StatusVendaException"/> if <paramref name="argument"/> is null.</summary>
    /// <param name="argument">The reference type argument to validate as non-null.</param>
    /// <param name="entityType">The entity type of the <paramref name="argument"/> parameter.</param>
    public static void ThrowIfFalse(bool argument, StatusVenda status)
    {
        if (!argument)
        {
            Throw(status);
        }
    }

    /// <summary>Throws an <see cref="StatusVendaException"/></summary>
    /// <param name="entityType">The entity type of the <paramref name="argument"/> parameter.</param>
    public static void Throw(StatusVenda entityType)
    {
        throw new StatusVendaException($"O Status {entityType} não é valido para esta venda.");
    }
}
