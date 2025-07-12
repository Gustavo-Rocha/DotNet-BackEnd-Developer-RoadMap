using AutoMapper;
using Estudos_NoSql.Domain.Entidades;
using Estudos_NoSql.Domain.Repositories;
using Estudos_NoSql.Shareable.Dto;
using Estudos_NoSql.Shareable.Request;
using Estudos_NoSql.Shareable.Response;
using MediatR;
using OperationResult;
using System.Collections.Generic;

namespace Estudos_NoSql.Domain.Handles;

public class ExcluiClienteRequestHandler : IRequestHandler<ExcluiClienteRequest, Result>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _autoMapper;

    public ExcluiClienteRequestHandler(IClienteRepository clienteService, IMapper autoMapper)
    {
        _clienteRepository = clienteService;
        _autoMapper = autoMapper;
    }

    public async Task<Result> Handle(ExcluiClienteRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            return new ApplicationException("cliente Nulo");

        var (sucesso, erro) = await _clienteRepository.DeletaCliente(request.IdCliente);

        return sucesso is true && erro is null
               ? Result.Success()
               : new ApplicationException("erro ao excluir Cliente");
    }
}
