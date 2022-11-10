namespace tech_test_payment_api.Application.Vendas.AtualizarVenda;

using Domain.Enum;
using FluentValidation;

public class AtualizarVendaValidator : AbstractValidator<AtualizarVendaCommand>
{
    public AtualizarVendaValidator()
    {
        _ = this.RuleFor(r => r.VendaId).NotNull().NotEqual(Guid.Empty).WithMessage("Venda não informada.");
        _ = this.RuleFor(r => r.StatusVenda).NotEqual(StatusVenda.AguardandoPagamento).WithMessage("Status Venda não informado.");
    }
}
