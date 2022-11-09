namespace tech_test_payment_api.Application.Vendas.RegistrarVenda;
using Domain.Models;
using MediatR;

public class RegistrarVendaCommand : IRequest<Venda>
{
    public Vendedor Vendedor { get; set; }
    public List<Item> ItensVendidos { get; set; }
}
