namespace tech_test_payment_api.Presentation.Endpoints.Venda;
using System.Diagnostics.CodeAnalysis;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using tech_test_payment_api.Presentation.Errors;
using Domain.Models;
using tech_test_payment_api.Application.Vendas.BuscarVenda;
using tech_test_payment_api.Application.Vendas.RegistrarVenda;
using Microsoft.AspNetCore.Http.Extensions;
using tech_test_payment_api.Application.Vendas.AtualizarVenda;
using Microsoft.AspNetCore.Http;

[ExcludeFromCodeCoverage]
public static class VendaEndpoint
{
    public static WebApplication MapVendaEndpoint(this WebApplication app)
    {
        _ = app.MapGet("/api/venda/{id:guid}",
                async (IMediator mediator, Guid id) =>
                    Results.Ok(await mediator.Send(new BuscarVendaQuery { Id = id })))
            .WithTags("Venda")
            .WithMetadata(new SwaggerOperationAttribute("Buscar venda por id", " GET /venda/id"))
            .Produces<Venda>(StatusCodes.Status200OK, contentType: MediaTypeNames.Application.Json)
            .Produces<ApiError>(StatusCodes.Status400BadRequest, contentType: MediaTypeNames.Application.Json)
            .Produces<ApiError>(StatusCodes.Status404NotFound, contentType: MediaTypeNames.Application.Json)
            .Produces<ApiError>(StatusCodes.Status500InternalServerError, contentType: MediaTypeNames.Application.Json);

        _ = app.MapPost("/api/venda",
                async (IMediator mediator, HttpRequest httpRequest, RegistrarVendaRequest request) =>
                         {
                             var command = new RegistrarVendaCommand()
                             {
                                 ItensVendidos = request.ObterItens(),
                                 Vendedor = request.ObterVendedor()
                             };

                             return Results.Created(UriHelper.GetEncodedUrl(httpRequest), await mediator.Send(command));
                         })
            .WithTags("Venda")
            .WithMetadata(new SwaggerOperationAttribute("Adicionar Venda", " POST /venda"))
            .Produces<Venda>(StatusCodes.Status201Created, contentType: MediaTypeNames.Application.Json)
            .Produces<ApiError>(StatusCodes.Status400BadRequest, contentType: MediaTypeNames.Application.Json)
            .Produces<ApiError>(StatusCodes.Status500InternalServerError, contentType: MediaTypeNames.Application.Json);


        _ = app.MapPut("/api/venda/{id:guid}",
                async (IMediator mediator, Guid id, AtualizarVendaRequest request) =>
                {
                    var command = new AtualizarVendaCommand
                    {
                        StatusVenda = request.StatusVenda,
                        VendaId = id
                    };

                    return Results.Ok(await mediator.Send(command));
                })
            .WithTags("Venda")
            .WithMetadata(new SwaggerOperationAttribute("Atualizar Venda", " PUT /venda/"))
            .Produces<bool>(StatusCodes.Status200OK, contentType: MediaTypeNames.Application.Json)
            .Produces<ApiError>(StatusCodes.Status400BadRequest, contentType: MediaTypeNames.Application.Json)
            .Produces<ApiError>(StatusCodes.Status500InternalServerError, contentType: MediaTypeNames.Application.Json);

        return app;

    }
}
