namespace Estudos_Middlewares.Middleware
{
    public class AutenticacaoCustomizadaMiddleware
    {
        private readonly RequestDelegate _next;
        public AutenticacaoCustomizadaMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAync(HttpContext context)
        {
            var autotizacao = context.Request.Headers.Authorization;
            if (!context.User.Identity.IsAuthenticated && autotizacao.Count is 0)
            {  
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Not Authorized Bro!");
                return;
            }


        }
    }
}
