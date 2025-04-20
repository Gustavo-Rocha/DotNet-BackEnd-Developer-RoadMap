using Estudos_GraphQL.Shareable.Dtos;
using MediatR;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_GraphQL.Shareable.Request;

public record class CadastraLivroRequest(LivroDto LivroRequestBody) : IRequest<Result>;
