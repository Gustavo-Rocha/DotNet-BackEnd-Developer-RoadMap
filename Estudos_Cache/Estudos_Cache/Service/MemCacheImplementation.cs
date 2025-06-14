using Estudos_Cache.Model;
using Estudos_Cache.Service.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Estudos_Cache.Service
{
    public class MemCacheImplementation : IMemCache
    {
        private readonly IMemoryCache _memoryCache;
        const string CHAVE_CACHE = "lista_livros";

        public MemCacheImplementation(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public void InsereLivros(LivroDto[] livros)
        {
            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
                SlidingExpiration = TimeSpan.FromMinutes(2)
            };
            _memoryCache.Set(CHAVE_CACHE,livros, cacheOptions);
        }

        public LivroDto[] RecuperLivros()
        {
            _memoryCache.TryGetValue(CHAVE_CACHE, out LivroDto[] listaLivros);

            return listaLivros is null
                   ? Array.Empty<LivroDto>()
                   : listaLivros;
        }
    }
}
