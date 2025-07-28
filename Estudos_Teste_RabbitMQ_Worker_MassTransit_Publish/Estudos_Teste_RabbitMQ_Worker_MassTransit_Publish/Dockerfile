# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Estudos_Teste_RabbitMQ_Worker_MassTransit_Publish/Estudos_Teste_RabbitMQ_Worker_MassTransit_Publish.csproj", "Estudos_Teste_RabbitMQ_Worker_MassTransit_Publish/"]
RUN dotnet restore "./Estudos_Teste_RabbitMQ_Worker_MassTransit_Publish/Estudos_Teste_RabbitMQ_Worker_MassTransit_Publish.csproj"
COPY . .
WORKDIR "/src/Estudos_Teste_RabbitMQ_Worker_MassTransit_Publish"
RUN dotnet build "./Estudos_Teste_RabbitMQ_Worker_MassTransit_Publish.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Estudos_Teste_RabbitMQ_Worker_MassTransit_Publish.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Estudos_Teste_RabbitMQ_Worker_MassTransit_Publish.dll"]