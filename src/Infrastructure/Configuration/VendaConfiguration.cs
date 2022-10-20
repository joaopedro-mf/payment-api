namespace tech_test_payment_api.Infrastructure.Configuration;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class VendaConfiguration : EntidadeConfiguration<Venda>
{
    public override void Configure(EntityTypeBuilder<Venda> builder)
    {
        base.Configure(builder);

        //_ = builder.HasMany(m => m.Item).WithOne(r => r).HasForeignKey(r => r.ReviewedMovieId);
        //_ = builder.HasOne(m => m.Vendedor).WithOne(r => r.Id)
    }
}
