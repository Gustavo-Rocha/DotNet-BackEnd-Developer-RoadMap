using Estudos_NoSql.Extensions;
using Estudos_NoSql.Shareable.Request;
using Estudos_NoSql.Shareable.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estudos_NoSql.Endpoints;

public static class Endpoints
{
    public static void MapAppEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/cadastraCliente", CadastraCliente)
                .WithName("cadastraCliente")
                .WithDisplayName("cadastraCliente")
                .WithTags("cadastraCliente")
                .Produces(200, typeof(ClienteResponse))
                .Produces(204);

        app.MapPost("api/v1/ListaCliente", ListaClientes)
                .WithName("cadastraCliente")
                .WithDisplayName("cadastraCliente")
                .WithTags("cadastraCliente")
                .Produces(200, typeof(ClienteResponse))
                .Produces(204);

        app.MapPost("api/v1/cadastraFilme", CadastraFilme)
                .WithName("cadastraFilme")
                .WithDisplayName("cadastraFilme")
                .WithTags("cadastraFilme")
                .Produces(200, typeof(ClienteResponse))
                .Produces(204);

    }

    private static async Task<IResult> CadastraCliente(IMediator mediator, [FromBody] ClienteRequestBody clienteRequestBody)
            => await mediator.SendCommand(new ClienteRequest(clienteRequestBody));

    private static async Task<IResult> ListaClientes(IMediator mediator, [AsParameters] FiltroClientes filtro)
            => await mediator.SendCommand(new ListaClienteRequest(filtro));

    private static async Task<IResult> CadastraFilme(IMediator mediator, [FromBody] FilmeRequestBody filmeRequestBody)
            => await mediator.SendCommand(new FilmeRequest(filmeRequestBody));
}
