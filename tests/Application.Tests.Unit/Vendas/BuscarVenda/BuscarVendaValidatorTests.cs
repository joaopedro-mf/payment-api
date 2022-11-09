namespace tech_test_payment_api.Application.Tests.Unit.Vendas.BuscarVenda;

using FluentValidation.TestHelper;
using tech_test_payment_api.Application.Vendas.BuscarVenda;
using Xunit;

public class BuscarVendaValidatorTests
{
    private static readonly BuscarVendaValidator Validator = new();


    [Fact]
    public void Validator_NaoDeveTerErroValidacaoPara_Id()
    {
        // Arrange
        var query = new BuscarVendaQuery();

        // Act
        var result = Validator.TestValidate(query);

        // Assert
        _ = result.ShouldHaveValidationErrorFor(query => query.Id);
    }

    [Fact]
    public void Validator_DeveTerErroValidacaoPara_IdNull()
    {
        // Arrange
        var query = new BuscarVendaQuery { Id = Guid.Empty };

        // Act
        var result = Validator.TestValidate(query);

        // Assert
        _ = result.ShouldHaveValidationErrorFor(query => query.Id);
    }
}
