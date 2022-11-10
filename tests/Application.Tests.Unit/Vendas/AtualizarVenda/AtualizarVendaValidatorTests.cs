namespace tech_test_payment_api.Application.Tests.Unit.Vendas.AtualizarVenda;
using System;
using Domain.Enum;
using FluentValidation.TestHelper;
using tech_test_payment_api.Application.Vendas.AtualizarVenda;
using Xunit;

public class AtualizarVendaValidatorTests
{
    private static readonly AtualizarVendaValidator Validator = new();


    [Fact]
    public void Validator_NaoDeveTerErroValidacaoPara_Id()
    {
        // Arrange
        var command = new AtualizarVendaCommand
        {
            VendaId = Guid.NewGuid(),
            StatusVenda = StatusVenda.Cancelada
        };

        // Act
        var result = Validator.TestValidate(command);

        // Assert
        result.ShouldNotHaveValidationErrorFor(command => command.VendaId);
        result.ShouldNotHaveValidationErrorFor(command => command.StatusVenda);
    }

    [Fact]
    public void Validator_DeveTerErroValidacaoPara_VendaIdNull()
    {
        // Arrange
        var command = new AtualizarVendaCommand
        {
            VendaId = Guid.Empty,
            StatusVenda = StatusVenda.Cancelada
        };

        // Act
        var result = Validator.TestValidate(command);

        // Assert
        _ = result.ShouldHaveValidationErrorFor(command => command.VendaId)
                  .WithErrorMessage("Venda não informada.");
    }

    [Fact]
    public void Validator_DeveTerErroValidacaoPara_StatusVendaNull()
    {
        // Arrange
        var command = new AtualizarVendaCommand
        {
            VendaId = Guid.NewGuid()
        };

        // Act
        var result = Validator.TestValidate(command);

        // Assert
        _ = result.ShouldHaveValidationErrorFor(command => command.StatusVenda)
                  .WithErrorMessage("Status Venda não informado.");
    }
}
