namespace Domain.Interfaces.Repository;
using System.Threading.Tasks;
using Domain.Enum;
using Domain.Models;

public interface IVendaRepository
{
    Task<Venda> ObterVendaPorId(Guid id, CancellationToken cancellation);
    void AtualizarVenda(Guid id, StatusVenda statusVenda, CancellationToken cancellation);
    void AdicionarVenda(Venda venda, CancellationToken cancellation);
}
