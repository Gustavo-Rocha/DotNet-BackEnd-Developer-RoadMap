
using MediatR;
using OperationResult;


namespace Estudos_NoSql.Shareable.Request;


public record ClienteRequest (ClienteRequestBody ClienteRequestBody) : IRequest<Result>;

public record class ClienteRequestBody 
{
    public string Nome { get; set; } = default!;

    public string Cpf { get; set; } = default!;

    public string Rua { get; set; } = default!;

    public string Cep { get; set; } = default!;

    public string Bairro { get; set; } = default!;

    public string Cidade { get; set; } = default!;

    public string UF { get; set; } = default!;

}
