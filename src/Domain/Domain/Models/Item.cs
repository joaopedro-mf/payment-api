namespace Domain.Models;

using Domain.Core;

public class Item : Entidade
{
    public Item() { }
    public Item(string descricao, float valor)
    {
        this.Descricao = descricao;
        this.Valor = valor;
    }
    public string Descricao { get; set; }
    public float Valor { get; set; }
}
