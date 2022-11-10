namespace tech_test_payment_api.Application.Vendas.RegistrarVenda;

using Domain.Models;

public class RegistrarVendaRequest
{
    public VendedorRequest Vendedor { get; set; }
    public List<ItemRequest> ItemsVendidos { get; set; }
    public Vendedor ObterVendedor()
    {
        return new(this.Vendedor.Cpf, this.Vendedor.Email, this.Vendedor.Telefone);
    }
    public List<Item> ObterItens()
    {
        var itens = new List<Item>();

        foreach (var item in this.ItemsVendidos)
        {
            itens.Add(new Item(item.Descricao, item.Valor));
        }

        return itens;
    }
}

public class VendedorRequest
{
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }

}

public class ItemRequest
{
    public string Descricao { get; set; }
    public float Valor { get; set; }
}
