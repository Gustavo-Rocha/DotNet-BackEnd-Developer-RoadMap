using Estudos_GraphQL.Domain.Repositorios;
using Estudos_GraphQL.Shareable.Request;
using Estudos_GraphQL.Shareable.Response;
using MediatR;
using OperationResult;

namespace Estudos_GraphQL.Domain.Handlers
{
    public class ListaLivrosRequestHandle : IRequestHandler<ListaLivroRequest, OperationResult.Result<LivrosResponse>>
    {
        private readonly ILivroRepository _livroRepository;
        public ListaLivrosRequestHandle(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public Task<OperationResult.Result<LivrosResponse>> Handle(ListaLivroRequest request, CancellationToken cancellationToken)
            => Result.Success(new LivrosResponse(_livroRepository.BuscaLivros()));
    }
}
