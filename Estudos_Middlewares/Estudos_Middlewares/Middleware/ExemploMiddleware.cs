namespace Estudos_Middlewares.Middleware
{
    public class ExemploMiddleware
    {
        private readonly RequestDelegate _next;

        public ExemploMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Middleware Personalizado: Antes");
            await _next(context);
            Console.WriteLine("Middleware Personalizado: Depois");
        }
    }
}
