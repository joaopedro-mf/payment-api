namespace Domain.Models;

using Domain.Core;

public class Vendedor : Entidade
{
    /*public Vendedor(string cpf, string email, string telefone)
    {
        this.Cpf = cpf;
        this.Email = email;
        this.Telefone = telefone;
    }*/
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }

}
