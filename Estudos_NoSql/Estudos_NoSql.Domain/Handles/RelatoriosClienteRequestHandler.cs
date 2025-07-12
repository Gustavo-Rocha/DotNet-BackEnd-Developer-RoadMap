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

public class RelatoriosClienteRequestHandler : IRequestHandler<RelatoriosClienteRequest, Result<ListaClienteResponse>>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _autoMapper;

    public RelatoriosClienteRequestHandler(IClienteRepository clienteService, IMapper autoMapper)
    {
        _clienteRepository = clienteService;
        _autoMapper = autoMapper;
    }

    public async Task<Result<ListaClienteResponse>> Handle(RelatoriosClienteRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            return new ApplicationException("cliente Nulo");

        var (sucesso, ListaDeCLientes, erro) = await _clienteRepository.GeraRelatoriosCliente(request.Filtro);

        return Result.Success(MontaResponse(ListaDeCLientes));
    }

    private ListaClienteResponse MontaResponse(List<ClienteEntity>? listaDeCLientes)
    {
        var listaResponse = new List<ClienteDto>();
        listaDeCLientes.ForEach(l =>
        listaResponse.Add(new ClienteDto
            {
                Id = l.Id,
                Nome = l.Nome,
                Cpf = l.Cpf,
                Cep = l.Cep,
                Rua = l.Rua,
                Bairro = l.Bairro,
                Cidade = l.Cidade,
                UF = l.UF
            })
        );

        return new ListaClienteResponse(listaResponse);
    }
}
