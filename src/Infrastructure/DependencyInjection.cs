namespace tech_test_payment_api.Infrastructure;

using System.Diagnostics.CodeAnalysis;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleDateTimeProvider;
using tech_test_payment_api.Infrastructure.Context;
using tech_test_payment_api.Infrastructure.Repository;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        _ = services.AddEntityFrameworkInMemoryDatabase();
        _ = services.AddDbContext<PaymentDbContext>(options => options.UseInMemoryDatabase($"vendas-{Guid.NewGuid()}"), ServiceLifetime.Singleton);

        _ = services.AddSingleton<IVendaRepository, VendaRepository>();
        _ = services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();

        return services;
    }
}
