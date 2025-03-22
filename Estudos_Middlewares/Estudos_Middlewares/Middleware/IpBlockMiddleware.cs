using Microsoft.AspNetCore.Http;
using System.Net;

namespace Estudos_Middlewares.Middleware
{
    public class IpBlockMiddleware
    {
        private readonly RequestDelegate _next;
        public IpBlockMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var listaIp = new List<string>() { "192.168.0.1", "127.0.0.0", "x", "::1", "192.168.15.9" };
            var ipRequest = context.Connection.RemoteIpAddress.MapToIPv4().ToString();
            Console.WriteLine($"Endereço de IP do Context {ipRequest}");

            if(listaIp.Contains(ipRequest))
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.Forbidden;
                
                await response.WriteAsync("Ip Bloqueado");
            }
            else
            {
                await _next(context);
            }
           
        }
    }
}
