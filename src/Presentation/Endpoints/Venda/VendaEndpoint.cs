namespace tech_test_payment_api.Presentation.Endpoints.Venda;

using MediatR;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics.CodeAnalysis;
using System.Net.Mime;
using tech_test_payment_api.Presentation.Errors;

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
