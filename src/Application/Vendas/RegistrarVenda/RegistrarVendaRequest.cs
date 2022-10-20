namespace tech_test_payment_api.Application.Vendas.RegistrarVenda;

using Domain.Models;

public class RegistrarVendaRequest
{
    public Vendedor Vendedor { get; set; }
    public List<Item> ItemsVendidos { get; set; }  
}
