using AutoMapper;
using Estudos_NoSql.Domain.Entidades;
using Estudos_NoSql.Domain.Repositories;
using Estudos_NoSql.Shareable.Request;
using Estudos_NoSql.Shareable.Response;
using MediatR;
using OperationResult;
using ApplicationException = System.ApplicationException;



namespace Estudos_NoSql.Domain.Handles;

public class ListaClientesRequestHandler : IRequestHandler<ListaClienteRequest, Result<ListaClienteResponse>>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _autoMapper;

    public ListaClientesRequestHandler(IClienteRepository clienteService, IMapper autoMapper)
    {
        _clienteRepository = clienteService;
        _autoMapper = autoMapper;
    }

    public async Task<Result<ListaClienteResponse>> Handle(ListaClienteRequest request, CancellationToken cancellationToken)
    {
        if (request is null)
            return new ApplicationException("cliente Nulo");

        ////var clienteDto = _autoMapper.Map<ClienteEntity>(request.ClienteRequestBody);
        //var clienteDto = new ClienteEntity
        //{
        //    Nome = request.ClienteRequestBody.Nome,
        //    Cpf = request.ClienteRequestBody.Cpf,
        //    Rua = request.ClienteRequestBody.Rua,
        //    Cep = request.ClienteRequestBody.Cep,
        //    Bairro = request.ClienteRequestBody.Bairro,
        //    Cidade = request.ClienteRequestBody.Cidade,
        //    UF = request.ClienteRequestBody.UF,
        //    DiasAluguelFilme = DateTime.Now
        //};
        var (sucesso, ListaDeCLientes, erro) = await _clienteRepository.ListaCliente(request.Filtro);

        return Result.Success( ListaDeCLientes);
    }

}
