using Estudos_GraphQL.Shareable.Response;
using MediatR;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_GraphQL.Shareable.Request
{
    public record  ListaLivroRequest() : IRequest<OperationResult.Result<LivrosResponse>>;
}
