namespace tech_test_payment_api.Application.Vendas.BuscarVenda;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces.Repository;
using Domain.Models;
using MediatR;
using tech_test_payment_api.Application.Common.Entities;
using tech_test_payment_api.Application.Common.Exceptions;

public class BuscarVendaHandler : IRequestHandler<BuscarVendaQuery, Venda>
{
    private readonly IVendaRepository repository;

    public BuscarVendaHandler(IVendaRepository repository)
    {
        this.repository = repository;
    }
    public async Task<Venda> Handle(BuscarVendaQuery request, CancellationToken cancellationToken)
    {
        var result = await this.repository.ObterVendaPorId(request.Id, cancellationToken);

        NotFoundException.ThrowIfNull(result, EntityType.Venda);

        return result;
    }
}
