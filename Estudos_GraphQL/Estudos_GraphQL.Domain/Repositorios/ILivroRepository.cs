namespace Estudos_GraphQL.Domain.Repositorios;

public interface ILivroRepository
{
    List<Shareable.Dtos.LivroDto> BuscaLivros();

    void CadastraLivro(Shareable.Dtos.LivroDto livro);

    Shareable.Dtos.LivroDto? BuscaLivroPorTitulo(string titulo);

    void AtualizaLivro(Shareable.Dtos.LivroDto livro);
}
