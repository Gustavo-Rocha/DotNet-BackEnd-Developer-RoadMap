using Estudos_NoSql.Domain.Entidades;
using Estudos_NoSql.Domain.Repositories;
using Estudos_NoSql.Shareable.Request;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var filter = builder.Eq(f => f.Nome , FiltroCliente.Nome);
            var lista = await _clienteCollection.FindAsync(filter);
            //var lista = _clienteCollection.AsQueryable().Where(f => filter.Inject()).ToList();

            return Result.Success(lista.ToList());
        }
    }
}
