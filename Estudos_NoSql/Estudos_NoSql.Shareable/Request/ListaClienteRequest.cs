using Estudos_NoSql.Shareable.Response;
using MediatR;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_NoSql.Shareable.Request
{
    public record ListaClienteRequest(FiltroClientes Filtro) : IRequest<Result<ListaClienteResponse>>;

    public record RelatoriosClienteRequest(FiltroClientes Filtro) : IRequest<Result<ListaClienteResponse>>;

}
