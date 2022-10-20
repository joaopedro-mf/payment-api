namespace tech_test_payment_api.Application.Vendas.BuscarVenda;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using MediatR;

public class BuscarVendaHandler : IRequestHandler<BuscarVendaCommand, Venda>
{
    public Task<Venda> Handle(BuscarVendaCommand request, CancellationToken cancellationToken)
    {
        //var result = await this.repository.GetAuthorById(request.Id, cancellationToken);

        //TODO: 
        return null;
    }
}
