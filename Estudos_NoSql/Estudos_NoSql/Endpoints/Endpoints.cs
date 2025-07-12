using Estudos_NoSql.Extensions;
using Estudos_NoSql.Shareable.Dto;
using Estudos_NoSql.Shareable.Request;
using Estudos_NoSql.Shareable.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OperationResult;

namespace Estudos_NoSql.Endpoints;

public static class Endpoints
{
    public static void MapAppEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/cliente/cadastraCliente", CadastraCliente)
                .WithName("cadastraCliente")
                .WithDisplayName("cadastraCliente")
                .WithTags("cadastraCliente")
                .Produces(200, typeof(ClienteResponse))
                .Produces(204);

        app.MapGet("api/v1/cliente/ListaCliente", ListaClientes)
                .WithName("ListaCliente")
                .WithDisplayName("ListaCliente")
                .WithTags("ListaCliente")
                .Produces(200, typeof(ListaClienteResponse))
                .Produces(204);

        app.MapPut("api/v1/cliente/AtualizaCliente", AtualizaCliente)
                .WithName("AtualizaCliente")
                .WithDisplayName("AtualizaCliente")
                .WithTags("AtualizaCliente")
                .Produces(200, typeof(Result))
                .Produces(204);

        app.MapDelete("api/v1/cliente/ExcluiCliente/{idCliente}", ExcluiCliente)
                .WithName("ExcluiCliente")
                .WithDisplayName("ExcluiCliente")
                .WithTags("ExcluiCliente")
                .Produces(200, typeof(Result))
                .Produces(204);

        app.MapDelete("api/v1/cliente/RelatoriosCliente", RelatoriosCliente)
               .WithName("RelatoriosCliente")
               .WithDisplayName("RelatoriosCliente")
               .WithTags("RelatoriosCliente")
               .Produces(200, typeof(Result))
               .Produces(204);

        app.MapPost("api/v1/filme/cadastraFilme", CadastraFilme)
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

    private static async Task<IResult> AtualizaCliente(IMediator mediator, [FromBody] ClienteDto cliente)
            => await mediator.SendCommand(new AtualizaClienteRequest(cliente));

    private static async Task<IResult> ExcluiCliente(IMediator mediator, string idCliente)
            => await mediator.SendCommand(new ExcluiClienteRequest(idCliente));

    private static async Task<IResult> RelatoriosCliente(IMediator mediator, [AsParameters] FiltroClientes filtro)
            => await mediator.SendCommand(new ListaClienteRequest(filtro));

    private static async Task<IResult> CadastraFilme(IMediator mediator, [FromBody] FilmeRequestBody filmeRequestBody)
            => await mediator.SendCommand(new FilmeRequest(filmeRequestBody));
}
