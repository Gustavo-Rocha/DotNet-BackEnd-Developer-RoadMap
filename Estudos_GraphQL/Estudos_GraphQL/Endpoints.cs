using Estudos_GraphQL.Extensions;
using Estudos_GraphQL.Shareable.Dtos;
using Estudos_GraphQL.Shareable.Request;
using Estudos_GraphQL.Shareable.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estudos_GraphQL
{
    public static class Endpoints
    {
        public static void MapAppEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/v1/livro/lista-livros", ListaLivros)
                    .WithName("cadastraCliente")
                    .WithDisplayName("cadastraCliente")
                    .WithTags("cadastraCliente")
                    .Produces(200, typeof(LivrosResponse))
                    .Produces(204);

            app.MapPost("api/v1/livro/cadastra-livro", CadastraLivro)
                    .WithName("cadastraFilme")
                    .WithDisplayName("cadastraFilme")
                    .WithTags("cadastraFilme")
                    .Produces(204);

        }

        private static async Task<IResult> ListaLivros(IMediator mediator)
                => await mediator.SendCommand(new ListaLivroRequest());

        private static async Task<IResult> CadastraLivro(IMediator mediator, [FromBody] LivroDto livroRequestBody)
                => await mediator.SendCommand(new CadastraLivroRequest(livroRequestBody));
    }
}
