using Estudos_NoSql.Domain.Entidades;
using Estudos_NoSql.Domain.Repositories;
using Estudos_NoSql.Shareable.Request;
using MongoDB.Driver;
using OperationResult;

namespace Estudos_NoSql.Infrastructure.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IMongoCollection<ClienteEntity> _clienteCollection;
        public ClienteRepository(IMongoCollection<ClienteEntity> clienteCollection)
        {
            _clienteCollection = clienteCollection;
        }

        public async Task<Result> CadastraCliente(ClienteEntity cliente)
        {
           await _clienteCollection.InsertOneAsync(cliente);
            return Result.Success();
        }

        public async Task<Result<List<ClienteEntity>>> ListaCliente(FiltroClientes FiltroCliente)
        {
            var builder = Builders<ClienteEntity>.Filter;
            var filter = builder.Eq(f => f.Nome, FiltroCliente.Nome) | builder.Eq(f => f.Cpf, "44638549896");

            if (FiltroCliente.Idade is null || string.IsNullOrEmpty(FiltroCliente.Nome))
                filter = builder.Empty;

            var lista = await _clienteCollection.Find(MontarFiltro(FiltroCliente))
                                                .Skip((FiltroCliente.Pagina - 1) * FiltroCliente.QuantidadeItensPorPagina)
                                                .Limit(FiltroCliente.QuantidadeItensPorPagina)
                                                .ToListAsync();
            //var lista = _clienteCollection.AsQueryable().Where(f => filter.Inject()).ToList();

            return Result.Success(lista.ToList());
        }

        public async Task<Result> AtualizaCliente(ClienteEntity cliente)
        {
            //var builder = Builders<ClienteEntity>.Filter;
            var filter = Builders<ClienteEntity>.Filter.Eq(f => f.Id, cliente.Id);

            //var update = Builders<ClienteEntity>.Update;
            var res = await _clienteCollection.ReplaceOneAsync(filter,cliente);
            return res.ModifiedCount is not 0
             ? Result.Success()
             : new ApplicationException("Erro ao atualizar entidade");
        }

        public async Task<Result> DeletaCliente(string idCliente)
        {
            var builder = Builders<ClienteEntity>.Filter;
            var filter = builder.Eq(f => f.Id, idCliente);
            await _clienteCollection.DeleteOneAsync(filter);

            return Result.Success();
        }

        public async Task<Result<List<ClienteEntity>>> GeraRelatoriosCliente(FiltroClientes FiltroCliente)
        {
            var builder = Builders<ClienteEntity>.Filter;
            var filter = builder.Eq(f => f.Nome, FiltroCliente.Nome) | builder.Eq(f => f.Cpf, "44638549896");

            var lista = await _clienteCollection.FindAsync(filter);
            //var lista = _clienteCollection.AsQueryable().Where(f => filter.Inject()).ToList();

            return Result.Success(lista.ToList());
        }

        public FilterDefinition<ClienteEntity> MontarFiltro(FiltroClientes filtro)
        {
            var builder = Builders<ClienteEntity>.Filter;

            var filtroFinal =
                (string.IsNullOrEmpty(filtro.Nome) ? builder.Empty : builder.Eq(c => c.Nome, filtro.Nome)) &
                (string.IsNullOrEmpty(filtro.Cpf) ? builder.Empty : builder.Eq(c => c.Cpf, filtro.Cpf)) &
                (string.IsNullOrEmpty(filtro.Cidade) ? builder.Empty : builder.Eq(c => c.Cidade, filtro.Cidade)) &
                (string.IsNullOrEmpty(filtro.UF) ? builder.Empty : builder.Eq(c => c.UF, filtro.UF));

        ////var filtroFinal =
        ////(string.IsNullOrEmpty(filtro.Nome) ? builder.Empty : builder.Eq(c => c.Nome, filtro.Nome)) &
        ////(string.IsNullOrEmpty(filtro.Cpf) ? builder.Empty : builder.Eq(c => c.Cpf, filtro.Cpf)) &
        ////(string.IsNullOrEmpty(filtro.Cidade) ? builder.Empty : builder.Eq(c => c.Cidade, filtro.Cidade)) &
        ////(string.IsNullOrEmpty(filtro.UF) ? builder.Empty : builder.Eq(c => c.UF, filtro.UF)) &
        ////(filtro.DataInicio is null ? builder.Empty : builder.Gte(c => c.DiasAluguelFilme, filtro.DataInicio.Value)) &
        ////(filtro.DataFim is null ? builder.Empty : builder.Lte(c => c.DiasAluguelFilme, filtro.DataFim.Value));


            return filtroFinal;
        }
    }
}
