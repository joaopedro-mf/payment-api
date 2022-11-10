namespace tech_test_payment_api.Application.Tests.Unit.Vendas.BuscarVenda;
using System.Threading.Tasks;
using Domain.Interfaces.Repository;
using Domain.Models;
using NSubstitute;
using Shouldly;
using tech_test_payment_api.Application.Vendas.BuscarVenda;
using Xunit;

public class BuscarVendaHandlerTests
{
    [Fact]
    public async Task Handle_DevePassar_ExecutarQuery()
    {
        // Arrange
        var query = new BuscarVendaQuery { Id = Guid.Empty };

        var context = Substitute.For<IVendaRepository>();
        var handler = new BuscarVendaHandler(context);
        var token = new CancellationTokenSource().Token;
        var emailArrange = "teste@teste.com";

        _ = context.ObterVendaPorId(Arg.Any<Guid>(), token).Returns(new Venda()
        {
            Vendedor = new Vendedor() { Email = emailArrange },
            Item = new List<Item>() { new Item() }
        });

        // Act
        var result = await handler.Handle(query, token);

        // Assert
        _ = await context.Received(1).ObterVendaPorId(query.Id, token);

        _ = result.ShouldNotBeNull();
        result.Vendedor.Email.ShouldBe(emailArrange);
        result.Item.Count.ShouldBe(1);
    }

}
