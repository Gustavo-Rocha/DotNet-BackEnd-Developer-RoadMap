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

public class AtualizaClientesRequestHandler : IRequestHandler<AtualizaClienteRequest, Result>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _autoMapper;

    public AtualizaClientesRequestHandler(IClienteRepository clienteService, IMapper autoMapper)
    {
        _clienteRepository = clienteService;
        _autoMapper = autoMapper;
    }

    public async Task<Result> Handle(AtualizaClienteRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            return new ApplicationException("cliente Nulo");

        ////var clienteDto = _autoMapper.Map<ClienteEntity>(request.ClienteRequestBody);
        var clienteEntity = new ClienteEntity
        {
            Id = request.cliente.Id,
            Nome = request.cliente.Nome,
            Cpf = request.cliente.Cpf,
            Rua = request.cliente.Rua,
            Cep = request.cliente.Cep,
            Bairro = request.cliente.Bairro,
            Cidade = request.cliente.Cidade,
            UF = request.cliente.UF,
            DiasAluguelFilme = DateTime.Now
        };
        var (sucesso, erro) = await _clienteRepository.AtualizaCliente(clienteEntity);

        return sucesso is true && erro is null
                ? Result.Success()
                : new ApplicationException("erro ao Atualizar Cliente");
    }    
}
