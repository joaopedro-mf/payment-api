namespace tech_test_payment_api.Application.Vendas.BuscarVenda;

using System.ComponentModel.DataAnnotations;
using Domain.Models;
using MediatR;

public class BuscarVendaCommand : IRequest<Venda>
{
    [Required]
    public Guid Id { get; init; }
}
