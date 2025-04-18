using Estudos_GraphQL.Domain.Repositorios;
using Estudos_GraphQL.Shareable.Dtos;
using Estudos_GraphQL.Shareable.Request.GraphQLInputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_GraphQL.Infra.GraphQlQueries;

public class LivrosMutationConfiguration
{

    public LivroDto MutationAdicionaLivro(
        [Service] ILivroRepository livroRepository,
        LivroInput livro)
    {
        var dto = new LivroDto
        {
            Titulo = livro.Titulo,
            Autor = livro.Autor,
            AnoPublicacao = Convert.ToDateTime(livro.AnoPublicacao)
        };

        livroRepository.CadastraLivro(dto);
        return livroRepository.BuscaLivroPorTitulo(dto.Titulo) ?? new();
    }

    public LivroDto MutationAtualizaLivro([Service] ILivroRepository livroRepository ,LivroInput livroInput, string nomeLivro)
    {
        var dto = new LivroDto
        {
            Titulo = livroInput.Titulo,
            Autor = livroInput.Autor,
            AnoPublicacao = Convert.ToDateTime(livroInput.AnoPublicacao)
        };

        
        livroRepository.AtualizaLivro(dto);

        return livroRepository.BuscaLivroPorTitulo(nomeLivro);
    }
}
