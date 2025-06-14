using Estudos_Cache.Service;
using Estudos_Cache.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IMemCache, MemCacheImplementation>();
builder.Services.AddScoped<IDistributedCacheService, DistributedCacheServiceImplementation>();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379"; // ou "host.docker.internal:6379" se sua app estiver em outro container
    options.InstanceName = "MinhaApp:";
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
