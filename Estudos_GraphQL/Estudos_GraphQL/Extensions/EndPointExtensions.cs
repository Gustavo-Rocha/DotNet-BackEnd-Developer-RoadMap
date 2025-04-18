using Estudos_GraphQL.Shareable.Response;
using MediatR;
using OperationResult;
using System.Net;

namespace Estudos_GraphQL.Extensions
{
    public static class EndPointExtensions
    {
        public static async Task<IResult> SendCommand<T>(this IMediator mediator, IRequest<Result<T>> request, Func<T, IResult>? result = null)
            => await mediator.Send(request) switch
            {
                (true, var response, _) => result is not null ? result(response!) : Results.Ok(response),
                var (_, _, error) => HandleError(error!)
            };

        public static async Task<IResult> SendCommand(this IMediator mediator, IRequest<Result> request, Func<IResult>? result = null)
            => await mediator.Send(request) switch
            {
                (true, _) => result is not null ? result() : Results.Ok(),
                var (_, error) => HandleError(error!)
            };

        private static IResult HandleError(Exception error) => error switch
        {
            ApplicationException e => new StatusCodeResult<ErroResponse>((int)HttpStatusCode.UnprocessableEntity, new ErroResponse(e.Message)),
            _ => Results.StatusCode(500)
        };

        private readonly record struct StatusCodeResult<T>(int StatusCode, T? Value) : IResult
        {
            public Task ExecuteAsync(HttpContext httpContext)
            {
                httpContext.Response.StatusCode = StatusCode;
                return Value is null
                    ? Task.CompletedTask
                    : httpContext.Response.WriteAsJsonAsync(Value, Value.GetType(), options: null, contentType: "application/json");
            }
        }
    }
}
