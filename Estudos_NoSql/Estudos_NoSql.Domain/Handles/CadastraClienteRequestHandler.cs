using AutoMapper;
using Estudos_NoSql.Domain.Entidades;
using Estudos_NoSql.Domain.Repositories;
using Estudos_NoSql.Shareable.Request;
using MediatR;
using OperationResult;
using ApplicationException = System.ApplicationException;



namespace Estudos_NoSql.Domain.Handles;

public class CadastraClienteRequestHandler : IRequestHandler<ClienteRequest, Result>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _autoMapper;

    public CadastraClienteRequestHandler(IClienteRepository clienteService, IMapper autoMapper)
    {
        _clienteRepository = clienteService;
        _autoMapper = autoMapper;
    }

    public async Task<Result> Handle(ClienteRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            return new ApplicationException("cliente Nulo");

        ////var clienteDto = _autoMapper.Map<ClienteEntity>(request.ClienteRequestBody);
        var clienteDto = new ClienteEntity
        {
            Nome = request.ClienteRequestBody.Nome,
            Cpf = request.ClienteRequestBody.Cpf,
            Rua = request.ClienteRequestBody.Rua,
            Cep = request.ClienteRequestBody.Cep,
            Bairro = request.ClienteRequestBody.Bairro,
            Cidade = request.ClienteRequestBody.Cidade,
            UF = request.ClienteRequestBody.UF,
            DiasAluguelFilme = DateTime.Now
        };
        var sucesso = await _clienteRepository.CadastraCliente(clienteDto);

        return Result.Success();
    }
}
