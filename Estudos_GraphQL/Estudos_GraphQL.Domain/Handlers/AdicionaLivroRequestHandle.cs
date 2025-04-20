using Estudos_GraphQL.Domain.Service;
using Estudos_GraphQL.Shareable.Request;
using MediatR;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_GraphQL.Domain.Handlers
{
    public class AdicionaLivroRequestHandle : IRequestHandler<CadastraLivroRequest, Result>
    {
        private readonly ILivroGrpcService _livroGprcService;
        public AdicionaLivroRequestHandle(ILivroGrpcService livroGprcService)
        {
            _livroGprcService = livroGprcService;
        }
        public Task<Result> Handle(CadastraLivroRequest request, CancellationToken cancellationToken)
        {
            return _livroGprcService.AdicionarLivros(request.LivroRequestBody);
        }
    }
}
