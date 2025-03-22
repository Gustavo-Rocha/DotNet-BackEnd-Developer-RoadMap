using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Estudos_Middlewares.Middleware
{

    public class TempoExecucaoMiddleware
    {
        private readonly RequestDelegate _next;

        public TempoExecucaoMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            await _next(context);
            stopWatch.Stop();
            Console.WriteLine($"Tempo Passado durante execucao de middleware é: {stopWatch.Elapsed.TotalSeconds}");
        }
    }
}
