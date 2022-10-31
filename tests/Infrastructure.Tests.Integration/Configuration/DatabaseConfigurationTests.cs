namespace tech_test_payment_api.Infrastructure.Tests.Integration.Configuration;

using Microsoft.EntityFrameworkCore;
using Shouldly;
using tech_test_payment_api.Infrastructure.Tests.Integration.Fixture;
using Xunit;

[Collection("Payment")]
public class DatabaseConfigurationTests
{
    private readonly PaymentDataFixture fixture;

    public DatabaseConfigurationTests(PaymentDataFixture fixture)
    {
        this.fixture = fixture;
    }

    #region Configuration

    [Fact]
    public async void Database_ShouldBe_Configured()
    {
        // Arrange
        var context = this.fixture.Context;
        var token = new CancellationTokenSource().Token;

        // Act
        // Assert
        context.Database.IsInMemory().ShouldBeTrue();

    }

    #endregion Configuration
}
