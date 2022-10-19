namespace Domain.Core;
using System;

public abstract class Entidade
{
    public Guid Id { get; set; }
    public DateTime DataCriacao { get; set; }
}
