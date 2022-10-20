namespace tech_test_payment_api.Infrastructure.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Enum;
using Domain.Interfaces.Repository;
using Domain.Models;
using tech_test_payment_api.Infrastructure.Context;

internal class VendaRepository : IVendaRepository
{
    private PaymentDbContext context;

    public VendaRepository(PaymentDbContext context)
    {
        this.context = context;
    }
    public void AdicionarVenda(Venda venda, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public void AtualizarVenda(Guid id, StatusVenda statusVenda, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<Venda> ObterVendaPorId(Guid id, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }
}
