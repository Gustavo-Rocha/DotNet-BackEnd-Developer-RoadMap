using Estudos_GraphQL.Domain.Repositorios;
using Estudos_GraphQL.Domain.Service;
using Estudos_GraphQL.Shareable.Request;
using Estudos_GraphQL.Shareable.Response;
using MediatR;
using OperationResult;

namespace Estudos_GraphQL.Domain.Handlers
{
    public class ListaLivrosRequestHandle : IRequestHandler<ListaLivroRequest, OperationResult.Result<LivrosResponse>>
    {
        private readonly ILivroRepository _livroRepository;
        private readonly ILivroGrpcService _livroGprcService;

        public ListaLivrosRequestHandle(ILivroRepository livroRepository, ILivroGrpcService livroGrpcService)
        {
            _livroRepository = livroRepository;
            _livroGprcService = livroGrpcService;
        }

        public async Task<OperationResult.Result<LivrosResponse>> Handle(ListaLivroRequest request, CancellationToken cancellationToken)
        {
           
            var livros = await _livroGprcService.ListarLivros();
            return Result.Success(new LivrosResponse(livros.Value));
        }
    }
}
