namespace tech_test_payment_api.Application.Vendas.BuscarVenda;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces.Repository;
using Domain.Models;
using MediatR;

public class BuscarVendaHandler : IRequestHandler<BuscarVendaQuery, Venda>
{
    private readonly IVendaRepository repository;

    public BuscarVendaHandler(IVendaRepository repository)
    {
        this.repository = repository;
    }
    public Task<Venda> Handle(BuscarVendaQuery request, CancellationToken cancellationToken)
    {
        //var result = await this.repository.GetAuthorById(request.Id, cancellationToken);

        //TODO: 
        return Task.FromResult(new Venda(new List<Item>(), new Vendedor()));
    }
}
