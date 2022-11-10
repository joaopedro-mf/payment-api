namespace tech_test_payment_api.Application.Vendas.AtualizarVenda;
using System;
using Domain.Enum;
using MediatR;

public class AtualizarVendaCommand : IRequest<bool>
{
    public Guid VendaId { get; set; }
    public StatusVenda StatusVenda { get; set; }
}
