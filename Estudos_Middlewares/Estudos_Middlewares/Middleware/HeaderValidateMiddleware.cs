namespace Estudos_Middlewares.Middleware
{
    public class HeaderValidateMiddleware
    {
        private readonly RequestDelegate _next;

        public HeaderValidateMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Middleware Personalizado: Antes");
            if(context.Request.Headers.ContainsKey("X-Api-Key"))
            {
                var apiKey = context.Request.Headers["X-Api-Key"];
                context.Request.Headers.Add("X-Api-Key", apiKey);
            }

            await _next(context);
            Console.WriteLine("Middleware Personalizado: Depois");
        }
    }
}
