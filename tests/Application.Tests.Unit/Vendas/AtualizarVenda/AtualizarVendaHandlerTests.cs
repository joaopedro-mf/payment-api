namespace Application.Tests.Unit.Vendas.AtualizarVenda;

using Domain.Enum;
using Domain.Interfaces.Repository;
using NSubstitute;
using Shouldly;
using tech_test_payment_api.Application.Common.Exceptions;
using tech_test_payment_api.Application.Vendas.AtualizarVenda;
using Xunit;

public class AtualizarVendaHandlerTests
{
    [Fact]
    public async Task Handle_DevePassarQuando_ExecutarCommand()
    {
        // Arrange
        var command = new AtualizarVendaCommand
        {
            VendaId = Guid.NewGuid(),
            StatusVenda = StatusVenda.Cancelada
        };
        var repository = Substitute.For<IVendaRepository>();

        _ = repository.AtualizarVenda(default, default, default).ReturnsForAnyArgs(true);

        var handler = new AtualizarVendaHandler(repository);
        var token = new CancellationTokenSource().Token;

        // Act
        _ = await handler.Handle(command, token);

        // Assert
        _ = await repository.Received(1).AtualizarVenda(command.VendaId, command.StatusVenda, token);
    }

    [Fact]
    public async Task Handle_DeveTerErroExcecao_VendaNaoExiste()
    {
        // Arrange
        var command = new AtualizarVendaCommand
        {
            VendaId = Guid.Empty,
            StatusVenda = StatusVenda.Cancelada
        };

        var repository = Substitute.For<IVendaRepository>();

        _ = repository.AtualizarVenda(default, default, default).ReturnsForAnyArgs(false);

        var handler = new AtualizarVendaHandler(repository);
        var token = new CancellationTokenSource().Token;

        // Act
       var result = await handler.Handle(command, token);

        // Assert

        _ = await repository.Received(1).AtualizarVenda(command.VendaId, command.StatusVenda, token);
        result.ShouldBeFalse();
    }

    [Fact]
    public async Task Handle_DeveTerErroExcecao_AlterarStatus_DeStatusAguardandoPagamento_ParaEnviadoTransportadora()
    {
        // Arrange
        var command = new AtualizarVendaCommand
        {
            VendaId = Guid.NewGuid(),
            StatusVenda = StatusVenda.EnviadoParaTransportadora
        };

        var repository = Substitute.For<IVendaRepository>();

        _ = repository.AtualizarVenda(default, default, default).ReturnsForAnyArgs(false);

        var handler = new AtualizarVendaHandler(repository);
        var token = new CancellationTokenSource().Token;

        // Act
        var exception = Should.Throw<StatusVendaException>(async () => await handler.Handle(command, token));

        // Assert
        exception.Message.ShouldBe("O Status EnviadoParaTransportadora não é valido para esta venda.");

        _ = await repository.DidNotReceive().AtualizarVenda(command.VendaId, command.StatusVenda, token);
    }

    [Fact]
    public async Task Handle_DeveTerErroExcecao_AlterarStatus_DeStatusAguardandoPagamento_ParaEntregue()
    {
        // Arrange
        var command = new AtualizarVendaCommand
        {
            VendaId = Guid.NewGuid(),
            StatusVenda = StatusVenda.Entregue
        };

        var repository = Substitute.For<IVendaRepository>();

        _ = repository.AtualizarVenda(default, default, default).ReturnsForAnyArgs(false);

        var handler = new AtualizarVendaHandler(repository);
        var token = new CancellationTokenSource().Token;

        // Act
        var exception = Should.Throw<StatusVendaException>(async () => await handler.Handle(command, token));

        // Assert
        exception.Message.ShouldBe("O Status Entregue não é valido para esta venda.");

        _ = await repository.DidNotReceive().AtualizarVenda(command.VendaId, command.StatusVenda, token);

    }

    [Fact]
    public async Task Handle_DeveTerErroExcecao_AlterarStatus_DePagamentoAprovado_ParaEntregue()
    {
        // Arrange
        var command = new AtualizarVendaCommand
        {
            VendaId = Guid.NewGuid(),
            StatusVenda = StatusVenda.Entregue
        };

        var repository = Substitute.For<IVendaRepository>();

        _ = repository.AtualizarVenda(default, default, default).ReturnsForAnyArgs(false);

        var handler = new AtualizarVendaHandler(repository);
        var token = new CancellationTokenSource().Token;

        // Act
        var exception = Should.Throw<StatusVendaException>(async () => await handler.Handle(command, token));

        // Assert
        exception.Message.ShouldBe("O Status Entregue não é valido para esta venda.");

        _ = await repository.DidNotReceive().AtualizarVenda(command.VendaId, command.StatusVenda, token);

    }

    [Fact]
    public async Task Handle_DeveTerErroExcecao_AlterarStatus_DeEnviadoTransportador_ParaCancelado()
    {
        // Arrange
        var command = new AtualizarVendaCommand
        {
            VendaId = Guid.NewGuid(),
            StatusVenda = StatusVenda.Cancelada
        };

        var repository = Substitute.For<IVendaRepository>();

        _ = repository.AtualizarVenda(default, default, default).ReturnsForAnyArgs(false);
        _ = repository.ObterStatusVendaPorId(default, default).ReturnsForAnyArgs(StatusVenda.EnviadoParaTransportadora);

        var handler = new AtualizarVendaHandler(repository);
        var token = new CancellationTokenSource().Token;

        // Act
        var exception = Should.Throw<StatusVendaException>(async () => await handler.Handle(command, token));

        // Assert
        exception.Message.ShouldBe("O Status Cancelada não é valido para esta venda.");

        _ = await repository.DidNotReceive().AtualizarVenda(command.VendaId, command.StatusVenda, token);

    }
}
