namespace tech_test_payment_api.Application.Vendas.RegistrarVenda;
using FluentValidation;

public class RegistrarVendaValidator : AbstractValidator<RegistrarVendaCommand>
{
    public RegistrarVendaValidator()
    {
        _ = this.RuleFor(r => r.Vendedor).NotNull().WithMessage("Vendedor não informado.");
        _ = this.RuleFor(r => r.ItensVendidos).NotEmpty().WithMessage("Lista de Itens Vazia.");
    }
}
