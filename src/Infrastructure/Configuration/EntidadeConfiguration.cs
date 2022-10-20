namespace tech_test_payment_api.Infrastructure.Configuration;
using Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal abstract class EntidadeConfiguration<T> : IEntityTypeConfiguration<T>
    where T : Entidade
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        _ = builder.HasKey(e => e.Id);
        _ = builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();
        _ = builder.Property(m => m.DataCriacao).ValueGeneratedOnAdd().IsRequired();
    }
}
