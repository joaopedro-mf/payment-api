namespace Domain.Core;
using System;
using System.Data;

public abstract class Entidade
{
    public Entidade()
    {
        this.Id = Guid.NewGuid();
        this.DataCriacao = DateTime.Now;
    }
    public Guid Id { get; set; }
    public DateTime DataCriacao { get; set; }
}
