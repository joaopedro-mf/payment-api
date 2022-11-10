namespace tech_test_payment_api.Application.Vendas.AtualizarVenda;
using System.Threading.Tasks;
using Domain.Enum;
using Domain.Interfaces.Repository;
using MediatR;
using tech_test_payment_api.Application.Common.Exceptions;

public class AtualizarVendaHandler : IRequestHandler<AtualizarVendaCommand, bool>
{
    private readonly IVendaRepository repository;

    public AtualizarVendaHandler(IVendaRepository repository)
    {
        this.repository = repository;
    }
    public async Task<bool> Handle(AtualizarVendaCommand request, CancellationToken cancellationToken)
    {
        var statusVenda = await this.repository.ObterStatusVendaPorId(request.VendaId, cancellationToken);

        StatusVendaException.ThrowIfFalse(this.ValidarStatusProduto(statusVenda, request.StatusVenda),
                                          request.StatusVenda);

        var result = await this.repository.AtualizarVenda(request.VendaId, request.StatusVenda, cancellationToken);

        //TODO: 
        return result;
    }

    private bool ValidarStatusProduto(StatusVenda statusVendaProduto, StatusVenda novoStatusProduto)
    {
        return statusVendaProduto switch
        {
            StatusVenda.AguardandoPagamento =>
                new[] { StatusVenda.PagamentoAprovado, StatusVenda.Cancelada }.Contains(novoStatusProduto),
            StatusVenda.PagamentoAprovado =>
                new[] { StatusVenda.EnviadoParaTransportadora, StatusVenda.Cancelada }.Contains(novoStatusProduto),
            StatusVenda.EnviadoParaTransportadora =>
                new[] { StatusVenda.Entregue }.Contains(novoStatusProduto),
            _ => false,
        };
    }
}
