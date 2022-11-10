namespace Domain.Interfaces.Repository;
using System.Threading.Tasks;
using Domain.Enum;
using Domain.Models;

public interface IVendaRepository
{
    Task<Venda> ObterVendaPorId(Guid id, CancellationToken cancellation);
    Task<bool> AtualizarVenda(Guid id, StatusVenda statusVenda, CancellationToken cancellation);
    Task<Venda> AdicionarVenda(List<Item> items, Vendedor vendedor, CancellationToken cancellation);
    Task<StatusVenda> ObterStatusVendaPorId(Guid id, CancellationToken cancellation);
}
