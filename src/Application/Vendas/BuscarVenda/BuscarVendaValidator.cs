namespace tech_test_payment_api.Application.Vendas.BuscarVenda;
using FluentValidation;

public class BuscarVendaValidator : AbstractValidator<BuscarVendaQuery>
{
    public BuscarVendaValidator()
    {
        _ = this.RuleFor(r => r.Id).NotNull().NotEqual(Guid.Empty).WithMessage("Id não fornecido.");
    }
}
