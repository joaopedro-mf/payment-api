namespace tech_test_payment_api.Application.Vendas.AtualizarVenda;
using System;
using Domain.Enum;

public class AtualizarVendaRequest
{
    public Guid VendaId { get; set; }
    public StatusVenda StatusVenda { get; set; }
}
