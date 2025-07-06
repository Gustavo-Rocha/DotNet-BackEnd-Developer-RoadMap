using Estudos_NoSql.Domain.Entidades;
using Estudos_NoSql.Shareable.Request;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_NoSql.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<Result> CadastraCliente(ClienteEntity cliente);

        Task<Result<List<ClienteEntity>>> ListaCliente(FiltroClientes FiltroCliente);
    }
}
