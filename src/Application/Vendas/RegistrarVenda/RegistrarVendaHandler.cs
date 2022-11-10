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

    public async Task<Venda> Handle(RegistrarVendaCommand request, CancellationToken cancellationToken)
    {
        return await this.repository.AdicionarVenda(request.ItensVendidos,request.Vendedor, cancellationToken);
    }
}
