namespace tech_test_payment_api.Infrastructure.Tests.Integration.Fixture;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleDateTimeProvider;
using tech_test_payment_api.Infrastructure.Context;
using tech_test_payment_api.Infrastructure.Repository;
using Xunit;

[CollectionDefinition("Payment")]
public class PaymentCollectionFixture : ICollectionFixture<PaymentDataFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}

public class PaymentDataFixture : IDisposable
{
    private bool disposedValue;

    internal PaymentDbContext Context { get; set; }
    internal IDateTimeProvider DateTimeProvider { get; set; }
    internal IMapper Mapper { get; set; }
    internal VendaRepository Repository { get; set; }

    public PaymentDataFixture()
    {
        var options = new DbContextOptionsBuilder<PaymentDbContext>().UseInMemoryDatabase($"Payment-{Guid.NewGuid()}").Options;

        this.Context = new PaymentDbContext(options);

        this.Repository = new VendaRepository(this.Context);

        if (this.Context != null)
        {
            _ = this.Context.Database.EnsureDeleted();
            _ = this.Context.Database.EnsureCreated();
            _ = this.Context.AddTestData();
        }
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposedValue)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }

            this.disposedValue = true;
        }
    }
}
