namespace Domain.Models
{
    using Domain.Core;
    using Domain.Enum;

    public class Venda : Entidade
    {
        public Venda() { } // Modelo para entity framework
        public Venda(List<Item> item, Vendedor vendedor)
        {
            this.StatusVenda = StatusVenda.AguardandoPagamento;
            this.Item = item;
            this.Vendedor = vendedor;
        }

        public StatusVenda StatusVenda { get; set; }
        public List<Item> Item { get; set; }
        public Vendedor Vendedor { get; set; }

    }
}
