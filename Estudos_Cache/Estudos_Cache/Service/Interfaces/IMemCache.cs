using Estudos_Cache.Model;

namespace Estudos_Cache.Service.Interfaces
{
    public interface IMemCache
    {
        void InsereLivros(LivroDto[] livros);

        LivroDto[] RecuperLivros();
    }
}
