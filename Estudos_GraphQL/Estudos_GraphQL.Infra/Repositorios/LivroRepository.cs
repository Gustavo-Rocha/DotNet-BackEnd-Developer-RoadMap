using Estudos_GraphQL.Domain.Repositorios;
using Estudos_GraphQL.Shareable.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_GraphQL.Infra.Repositorios
{
    public class LivroRepository : ILivroRepository
    {
        private static List<LivroDto> LISTA_LIVRO =  GerarListaLivros(100);

        public List<LivroDto> BuscaLivros()
            => GerarListaLivros(100);
        
        static List<LivroDto> GerarListaLivros(int quantidade)
        {
            var random = new Random();
            string[] autores = { "Machado de Assis", "Clarice Lispector", "Monteiro Lobato", "Graciliano Ramos", "Cecília Meireles" };
            string[] titulos = { "O Alienista", "A Hora da Estrela", "Sítio do Picapau Amarelo", "Vidas Secas", "Romanceiro da Inconfidência" };

            return Enumerable.Range(1, quantidade).Select(i => new LivroDto
            {
                Titulo = $"{titulos[random.Next(titulos.Length)]} {i}", // Garante títulos diferentes
                Autor = autores[random.Next(autores.Length)],
                AnoPublicacao = new DateTime(random.Next(1900, 2024), 1, 1) // Anos entre 1900 e 2023
            }).ToList();
        }

        public void CadastraLivro(LivroDto livro)
        {
            var lista = LISTA_LIVRO;
                
            lista.Add(livro);
        }

        public LivroDto? BuscaLivroPorTitulo(string titulo)
            => LISTA_LIVRO.FirstOrDefault(x => x.Titulo.Equals(titulo, StringComparison.InvariantCultureIgnoreCase));

        public void AtualizaLivro(LivroDto livro)
        {
            var livros = LISTA_LIVRO;

            var ll = livros.FirstOrDefault(l => l.Titulo.Contains(livro.Titulo));

            livros.Remove(ll);

            livros.Add(livro);
        }
    }
}
