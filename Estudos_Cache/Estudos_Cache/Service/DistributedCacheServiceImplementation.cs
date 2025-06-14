using Estudos_Cache.Model;
using Estudos_Cache.Service.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Estudos_Cache.Service
{
    public class DistributedCacheServiceImplementation : IDistributedCacheService
    {
        private readonly IDistributedCache _distributedCache;
        const string CHAVE_CACHE = "lista_livros";

        public DistributedCacheServiceImplementation(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task  InsereLivrosDistributedCache(LivroDto[] livros)
        {
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1),
                SlidingExpiration = TimeSpan.FromMinutes(2)
            };
            var livrosSerializado = JsonSerializer.Serialize<LivroDto[]>(livros);
            await _distributedCache.SetStringAsync(CHAVE_CACHE, livrosSerializado, cacheOptions);
        }

        public async Task<LivroDto[]> RecuperLivrosDistributedCache()
        {
            var livrosNoCache = await _distributedCache.GetStringAsync(CHAVE_CACHE);
            var livrosDeserializados = Array.Empty<LivroDto>();

            if (!string.IsNullOrEmpty(livrosNoCache))
                livrosDeserializados = JsonSerializer.Deserialize<LivroDto[]>(livrosNoCache);

            return livrosDeserializados.Length is 0
                   ? Array.Empty<LivroDto>()
                   : livrosDeserializados;
        }
    }
}
