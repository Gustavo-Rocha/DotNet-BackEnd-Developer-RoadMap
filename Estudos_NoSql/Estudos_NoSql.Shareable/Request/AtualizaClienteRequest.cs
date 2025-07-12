using Estudos_NoSql.Shareable.Dto;
using MediatR;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_NoSql.Shareable.Request;

    public record AtualizaClienteRequest(ClienteDto cliente) : IRequest<Result>;
