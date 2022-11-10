namespace tech_test_payment_api.Application.Tests.Unit.Vendas.RegistrarVenda;

using Domain.Models;
using FluentValidation.TestHelper;
using tech_test_payment_api.Application.Vendas.RegistrarVenda;
using Xunit;

public class RegistrarVendaValidatorTests
{
    private static readonly RegistrarVendaValidator Validator = new();

    [Fact]
    public void Validator_NaoDeveTerErroValidacaoPara_Venda_Vendedor()
    {
        // Arrange
        var command = new RegistrarVendaCommand
        {
            Vendedor = new Vendedor(),
            ItensVendidos = new List<Item>() { new Item() }
        };

        // Act
        var result = Validator.TestValidate(command);

        // Assert
        result.ShouldNotHaveValidationErrorFor(command => command.Vendedor);
        result.ShouldNotHaveValidationErrorFor(command => command.ItensVendidos);
    }

    [Fact]
    public void Validator_DeveTerErroValidacaoPara_VendasNull()
    {
        // Arrange
        var command = new RegistrarVendaCommand
        {
            Vendedor = new Vendedor(),
            ItensVendidos = new List<Item>()
        };

        // Act
        var result = Validator.TestValidate(command);

        // Assert
        _ = result.ShouldHaveValidationErrorFor(command => command.ItensVendidos)
                  .WithErrorMessage("Lista de Itens Vazia.");
    }

    [Fact]
    public void Validator_DeveTerErroValidacaoPara_VendedorNull()
    {
        // Arrange
        var command = new RegistrarVendaCommand
        {
            Vendedor = null,
            ItensVendidos = new List<Item>()
        };

        // Act
        var result = Validator.TestValidate(command);

        // Assert
        _ = result.ShouldHaveValidationErrorFor(command => command.Vendedor)
                  .WithErrorMessage("Vendedor não informado.");
    }
}
