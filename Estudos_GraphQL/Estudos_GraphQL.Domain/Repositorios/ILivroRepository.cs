using Estudos_GraphQL.Shareable.Dtos;
using Estudos_GraphQL.Shareable.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_GraphQL.Domain.Repositorios;

public interface ILivroRepository
{
    List<LivroDto> BuscaLivros();

    void CadastraLivro(LivroDto livro);

    LivroDto? BuscaLivroPorTitulo(string titulo);

    void AtualizaLivro(LivroDto livro);
}
