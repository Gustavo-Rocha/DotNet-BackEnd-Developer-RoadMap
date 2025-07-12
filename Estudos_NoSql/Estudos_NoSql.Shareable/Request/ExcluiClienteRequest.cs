using MediatR;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_NoSql.Shareable.Request;

    public record ExcluiClienteRequest(string IdCliente) : IRequest<Result>;

