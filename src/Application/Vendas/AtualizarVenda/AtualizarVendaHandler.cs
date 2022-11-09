namespace tech_test_payment_api.Application.Vendas.AtualizarVenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Repository;
using Domain.Models;
using MediatR;
using tech_test_payment_api.Application.Vendas.BuscarVenda;

public class AtualizarVendaHandler : IRequestHandler<AtualizarVendaCommand, bool>
{
    private readonly IVendaRepository repository;

    public AtualizarVendaHandler(IVendaRepository repository)
    {
        this.repository = repository;
    }
    public Task<bool> Handle(AtualizarVendaCommand request, CancellationToken cancellationToken)
    {
        //var result = await this.repository.GetAuthorById(request.Id, cancellationToken);

        //TODO: 
        return Task.FromResult(true);
    }
}
