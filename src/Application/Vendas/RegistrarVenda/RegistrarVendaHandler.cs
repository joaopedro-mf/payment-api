namespace tech_test_payment_api.Application.Vendas.RegistrarVenda;
using Domain.Interfaces.Repository;
using Domain.Models;
using MediatR;

public class RegistrarVendaHandler : IRequestHandler<RegistrarVendaCommand, Venda>
{
    private readonly IVendaRepository repository;

    public RegistrarVendaHandler(IVendaRepository repository)
    {
        this.repository = repository;
    }

    public Task<Venda> Handle(RegistrarVendaCommand request, CancellationToken cancellationToken)
    {
        //var result = await this.repository.GetAuthorById(request.Id, cancellationToken);

        //TODO:
        return Task.FromResult(new Venda(new List<Item>(), new Vendedor()));
    }
}
