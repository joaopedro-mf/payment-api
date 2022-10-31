namespace tech_test_payment_api.Infrastructure.Tests.Integration.Repository;
using System.Linq;
using tech_test_payment_api.Infrastructure.Tests.Integration.Fixture;
using Xunit;
using Shouldly;
using Domain.Enum;

[Collection("Payment")]
public class VendaRepositoryTests
{
    private readonly PaymentDataFixture fixture;

    public VendaRepositoryTests(PaymentDataFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async void AdicionarVenda_DeveReturnar_NovaVenda()
    {
        // Arrange
        var repository = this.fixture.Repository;
        var token = new CancellationTokenSource().Token;
        var venda = this.fixture.Context.Vendas.FirstOrDefault();

        // Act
        var result = repository.AdicionarVenda(venda, token);

        // Assert
        _ = result.ShouldNotBeNull();
        result.Id.ShouldBe(venda.Id);
    }

    [Fact]
    public async void AtualizarVenda_DeveReturnar_Ok()
    {
        // Arrange
        var repository = this.fixture.Repository;
        var token = new CancellationTokenSource().Token;
        var venda = this.fixture.Context.Vendas.FirstOrDefault();

        // Act
        repository.AtualizarVenda(venda.Id, StatusVenda.Cancelada, token);

        // Assert
        var vendaAssert = this.fixture.Context.Vendas.FirstOrDefault(x => x.Id == venda.Id);
        vendaAssert.StatusVenda.ShouldBe(StatusVenda.Cancelada);
    }

    [Fact]
    public async void ObterVendaPorId_DeveReturnar_Venda()
    {
        // Arrange
        var repository = this.fixture.Repository;
        var token = new CancellationTokenSource().Token;
        var venda = this.fixture.Context.Vendas.FirstOrDefault();

        // Act
        var result = await repository.ObterVendaPorId(venda.Id, token);

        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(venda.Id);
    }

}
