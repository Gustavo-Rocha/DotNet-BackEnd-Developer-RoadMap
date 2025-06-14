using Estudos_Cache.Model;
using Estudos_Cache.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Distributed;

namespace Estudos_Cache.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteCachesController : ControllerBase
    {
        private static LivroDto[] livros;
        private readonly IMemCache _memCache;
        private readonly IDistributedCacheService _distributedCacheService;
        private readonly ILogger<TesteCachesController> _logger;

        public TesteCachesController(ILogger<TesteCachesController> logger, IMemCache memCache, IDistributedCacheService distributedCacheService)
        {
            _logger = logger;
            livros = GerarListaLivros(5);
            _memCache = memCache;
            _distributedCacheService = distributedCacheService;
        }

        //[HttpGet(Name = "GetLivrosMemoryCache")]
        [HttpGet("GetLivros-MemoryCache")]
        public IEnumerable<LivroDto> Get()
        {
            var livrosDoCache = _memCache.RecuperLivros();
            switch (livrosDoCache.Length)
            {
                case 0:
                    _memCache.InsereLivros(livros);
                    return livros;
                default:
                    return livrosDoCache;
            }
        }

        [HttpGet("GetLivros-DistributedCache")]
        public async Task<IEnumerable<LivroDto>> GetLivrosDistributedCache()
        {
            var livrosDoDistributedCache = await _distributedCacheService.RecuperLivrosDistributedCache();
            switch (livrosDoDistributedCache.Length)
            {
                case 0:
                    _distributedCacheService.InsereLivrosDistributedCache(livros);
                    return livros;
                default:
                    return livrosDoDistributedCache;
            }
        }

        private static LivroDto[] GerarListaLivros(int quantidade)
        {
            var random = new Random();
            string[] autores = { "Machado de Assis", "Clarice Lispector", "Monteiro Lobato", "Graciliano Ramos", "Cecília Meireles" };
            string[] titulos = { "O Alienista", "A Hora da Estrela", "Sítio do Picapau Amarelo", "Vidas Secas", "Romanceiro da Inconfidência" };

            return Enumerable.Range(1, quantidade).Select(i => new LivroDto
            {
                Titulo = $"{titulos[random.Next(titulos.Length)]} {i}", // Garante títulos diferentes
                Autor = autores[random.Next(autores.Length)],
                AnoPublicacao = new DateTime(random.Next(1900, 2024), 1, 1) // Anos entre 1900 e 2023
            }).ToArray();
        }
    }
}
