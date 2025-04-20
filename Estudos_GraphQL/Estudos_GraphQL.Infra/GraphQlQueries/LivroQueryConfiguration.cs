using Estudos_GraphQL.Domain.Repositorios;
using Estudos_GraphQL.Shareable.Dtos;

namespace Estudos_GraphQL.Infra.GraphQlQueries
{
    public class LivroQueryConfiguration
    {
        public LivroQueryConfiguration()
        {

        }
        public List<Shareable.Dtos.LivroDto> QueryBuscaTodosLivros([Service] ILivroRepository livroRepository)
            => livroRepository.BuscaLivros();
    }
}
