using Estudos_GraphQL.Shareable;
using Estudos_GraphQL.Shareable.Dtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_GraphQL.Domain.Service;

public class LivroGrpcService : ILivroGrpcService
{
    private readonly LivroService.LivroServiceClient _livroServiceClient;
    public LivroGrpcService(LivroService.LivroServiceClient livroServiceClient)
    {
        _livroServiceClient = livroServiceClient;
    }

    public async Task<Result> AdicionarLivros(Shareable.Dtos.LivroDto livro)
    {
        var request = new LivroRequest
        {
            Livro = new LivroDto
            {
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                AnoPublicacao = Timestamp.FromDateTime(livro.AnoPublicacao)
            }
        };

        var response = await _livroServiceClient.AdicionarLivroAsync(request);

        return Result.Success();
    }

    public async Task<OperationResult.Result<List<Shareable.Dtos.LivroDto>>> ListarLivros()
    {

        var response = await _livroServiceClient.ListarLivrosAsync(new Empty());

        var lista = new List<Shareable.Dtos.LivroDto>();
        foreach (var item in response.Livros)
        {
            var dto = new Shareable.Dtos.LivroDto
            {
                Titulo = item.Titulo,
                Autor = item.Autor,
                AnoPublicacao = item.AnoPublicacao.ToDateTime()
            };

            lista.Add(dto);
        }

        return Result.Success(lista);
    }

}
