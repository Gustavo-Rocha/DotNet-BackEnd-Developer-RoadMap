using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static Estudos_gRPC.LivroService;

namespace Estudos_gRPC.Services
{
    public class LivroService : LivroServiceBase
    {
        private static readonly List<LivroDto> Livros = new();

        public override Task<Empty> AdicionarLivro(LivroRequest request, ServerCallContext context)
        {
            Livros.Add(request.Livro);
            return Task.FromResult(new Empty());
        }

        public override Task<LivroResponse> ListarLivros(Empty request, ServerCallContext context)
        {
            var response = new LivroResponse();
            response.Livros.AddRange(Livros);
            return Task.FromResult(response);
        }
    }
}
