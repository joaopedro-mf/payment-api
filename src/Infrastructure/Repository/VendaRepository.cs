namespace tech_test_payment_api.Infrastructure.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Enum;
using Domain.Interfaces.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Infrastructure.Context;

internal class VendaRepository : IVendaRepository
{
    private readonly PaymentDbContext context;

    public VendaRepository(PaymentDbContext context)
    {
        this.context = context;
    }
    public async Task<Venda> AdicionarVenda(List<Item> items, Vendedor vendedor, CancellationToken cancellation)
    {
        var venda = new Venda(items, vendedor);

        var id = this.context.Add(venda).Entity.Id;

        _ = await this.context.SaveChangesAsync(cancellation);

        var result = await this.context.Vendas.Where(v => v.Id == id)
                                              .Include(v => v.Vendedor)
                                              .Include(v => v.Item)
                                              .AsNoTracking()
                                              .FirstOrDefaultAsync(cancellation);

        return result;
    }

    public async Task<bool> AtualizarVenda(Guid id, StatusVenda statusVenda, CancellationToken cancellation)
    {
        var venda = this.context.Vendas.FirstOrDefault(v => v.Id == id);

        if (venda is null)
            return false;

        var sucesso = venda.AtualizarVenda(statusVenda);

        _ = this.context.Update(venda);
        _ = await this.context.SaveChangesAsync(cancellation);

        return sucesso;

    }

    public async Task<Venda> ObterVendaPorId(Guid id, CancellationToken cancellation)
    {
        return await this.context.Vendas.Where(v => v.Id == id)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(cancellation);
    }
}
