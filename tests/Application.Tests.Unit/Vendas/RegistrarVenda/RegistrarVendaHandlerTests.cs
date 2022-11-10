namespace tech_test_payment_api.Application.Tests.Unit.Vendas.RegistrarVenda;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.Repository;
using Domain.Models;
using NSubstitute;
using Shouldly;
using tech_test_payment_api.Application.Vendas.BuscarVenda;
using tech_test_payment_api.Application.Vendas.RegistrarVenda;
using Xunit;

public class RegistrarVendaHandlerTests
{
    [Fact]
    public async Task Handle_DevePassar_ExecutarCommand()
    {
        // Arrange
        var emailArrange = "teste@teste.com";
        var vendedorArange = new Vendedor() { Email = emailArrange };
        var itensVendidosArrange = new List<Item>() { new Item() { Valor = 10 } };
        var query = new RegistrarVendaCommand
        {
            Vendedor = vendedorArange,
            ItensVendidos = itensVendidosArrange
        };

        var context = Substitute.For<IVendaRepository>();
        var handler = new RegistrarVendaHandler(context);
        var token = new CancellationTokenSource().Token;


        _ = context.AdicionarVenda(Arg.Any<List<Item>>(), Arg.Any<Vendedor>(), token)
                   .Returns(new Venda() { Vendedor = vendedorArange, Item = itensVendidosArrange });

        // Act
        var result = await handler.Handle(query, token);

        // Assert
        _ = await context.Received(1).AdicionarVenda(query.ItensVendidos, query.Vendedor, token);

        _ = result.ShouldNotBeNull();
        result.Vendedor.Email.ShouldBe(emailArrange);
        result.Item.Count.ShouldBe(1);
    }
}
