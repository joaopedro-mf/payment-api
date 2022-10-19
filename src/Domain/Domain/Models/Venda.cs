using Domain.Core;
using Domain.Enum;

namespace Domain.Models
{
    public class Venda : Entidade
    {
        public Venda(StatusVenda statusVenda, List<Item> item, Vendedor vendedor)
        {
            this.StatusVenda = statusVenda;
            this.Item = item;
            this.Vendedor = vendedor;
        }

        public StatusVenda StatusVenda { get; set; }
        public List<Item> Item { get; set; }
        public Vendedor Vendedor { get; set; }
    }
}
