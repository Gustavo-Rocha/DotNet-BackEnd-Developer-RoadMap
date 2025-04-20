using Estudos_gRPC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure the HTTP request pipeline.
// Adiciona os serviços gRPC
builder.Services.AddGrpc();

//  Adiciona suporte a Reflection
builder.Services.AddGrpcReflection();

var app = builder.Build();

// Mapeia seus serviços gRPC aqui
app.MapGrpcService<GreeterService>();

app.MapGrpcService<LivroService>();

//  Ativa o Reflection no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
}
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
