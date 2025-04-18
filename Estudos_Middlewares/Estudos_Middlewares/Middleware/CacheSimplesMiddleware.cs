using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Estudos_Middlewares.Middleware
{
    public class CacheSimplesMiddleware
    {
        private readonly RequestDelegate _next;
        private Dictionary<string,List<WeatherForecast>> _cache = new();

        public CacheSimplesMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string cacheKey = string.Empty;
            var endPoint = context.Request.Path;
            if(!endPoint.ToString().Contains("/weatherforecast"))
            {
                await _next(context);
                return;
                
            }
            cacheKey = context.Request.Path.ToString();

            if (_cache.TryGetValue(cacheKey, out List<WeatherForecast> cachedResponse))
            {
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize<List<WeatherForecast>>(cachedResponse).ToString());
                return;
            }
            
            var originalBodyStream = context.Response.Body;
            using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            await _next(context);

            memoryStream.Seek(0, SeekOrigin.Begin);
            string responseBody = await new StreamReader(memoryStream).ReadToEndAsync();

            _cache[cacheKey] = JsonSerializer.Deserialize<List<WeatherForecast>>( responseBody);

            memoryStream.Seek(0, SeekOrigin.Begin);
            await memoryStream.CopyToAsync(originalBodyStream);

            //await _next(context);
            

        }
    }
}
