using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Estudos_Middlewares.Middleware
{
    public class ManipulandoBodyMiddleware
    {
        private readonly RequestDelegate _next;

        public ManipulandoBodyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.Path.ToString().Contains("/GetSensacao"))
            {
                context.Request.EnableBuffering();

                using var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true);
                string bodyString = await reader.ReadToEndAsync();
                context.Request.Body.Position = 0;
                if (string.IsNullOrWhiteSpace(bodyString))
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("O corpo da requisição está vazio.");
                    return;
                }
                var sj = JsonNode.Parse(bodyString).AsObject();

                sj.Insert(1, "NovaPropriedade", "Irineu voce nao sabe e nem eu");

                await _next(context);
            }
        }
    }
}
