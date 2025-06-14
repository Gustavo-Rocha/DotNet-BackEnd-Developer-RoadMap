using Estudos_Cache.Model;

namespace Estudos_Cache.Service.Interfaces
{
    public interface IDistributedCacheService
    {
        Task InsereLivrosDistributedCache(LivroDto[] livros);

        Task<LivroDto[]> RecuperLivrosDistributedCache();
    }
}