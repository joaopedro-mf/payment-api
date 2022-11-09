namespace tech_test_payment_api.Presentation.Endpoints.Venda;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public static class VendaEndpoint
{
    public static WebApplication MapVendaEndpoint(this WebApplication app)
    {
        _ = app.MapGet("/api/venda/{id:guid}",
                        () => Results.Ok());

        _ = app.MapPost("/api/venda",
                         () => Results.Ok());

        _ = app.MapPut("/api/venda/{id:guid}",
                        () => Results.Ok());
        return app;
    }
}
