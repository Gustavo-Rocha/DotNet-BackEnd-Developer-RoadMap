
namespace Estudos_GraphQL.Domain.Service
{
    public interface ILivroGrpcService
    {
        public Task<OperationResult.Result<List<Shareable.Dtos.LivroDto>>> ListarLivros();

        public Task<OperationResult.Result> AdicionarLivros(Shareable.Dtos.LivroDto livro);
    }
}