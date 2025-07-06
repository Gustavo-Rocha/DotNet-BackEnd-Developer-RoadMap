using Estudos_NoSql.Domain;
using Estudos_NoSql.Domain.Entidades;
using Estudos_NoSql.Domain.Repositories;
using Estudos_NoSql.Infrastructure.Repository;
using Estudos_NoSql.Shareable.AppConfig;
using Locadora_Publisher.Shareable;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Estudos_NoSql.IOC
{
    public static class AppServiceCollectionExtensions
    {
        public static void ConfigureAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ShareableEntrypoint).Assembly);

            services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(DomainEntryPoint).Assembly));

            services.AddScoped<IClienteRepository, ClienteRepository>();
            //services.AddScoped<IFilmeRepository, FilmeRepository>();
            //services.AddScoped<IEventPublisher, Publisher>();

            ////services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration["ConnectionString:Default"]));

            var mongoDbConfig = configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
            ////configuration.GetSection("MongoDBSettings").Bind(mongoDbSettings);
            ////configuration.GetSection("MongoDBSettings:DatabaseSettings").Bind(mongoDbSettings.DatabaseSettings);
            //services.Configure<MongoDBSettings>(configuration.GetSection("MongoDBSettings"));
            ConfigureMongoDbClient(services, mongoDbConfig);
            ConfigureClienteCollection(services, mongoDbConfig);
        }

        

        private static IServiceCollection ConfigureMongoDbClient(IServiceCollection services, MongoDBSettings mongoDbConfig)
        {
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if(envName != "Development")
            {
                var mongoCLient = new MongoClient(mongoDbConfig.ConnectionString);
                services.AddHealthChecks().AddMongoDb(
                    sp => new MongoClient(mongoDbConfig.ConnectionString),
                    name: "Estudos_NoSql",
                    tags: new[] { "Database" },
                    timeout: TimeSpan.FromMicroseconds(3000.0));
            }

            BsonClassMap.RegisterClassMap<ClienteEntity>(classMap =>
            {
                classMap.AutoMap();
                classMap.SetIgnoreExtraElements(true);
                classMap.MapIdField(x => x.Id)
                .SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetSerializer(new StringSerializer(MongoDB.Bson.BsonType.ObjectId))
                .SetIgnoreIfDefault(true);
            });

            services.AddScoped(sp => mongoDbConfig);
            services.AddSingleton(sp => new MongoClient(mongoDbConfig.ConnectionString));
            return services;
        }

        private static IServiceCollection ConfigureClienteCollection(IServiceCollection services, MongoDBSettings? mongoDbConfig)
        {
            var config = mongoDbConfig.DatabaseSettings;
            services.AddScoped(sp => config);
            services.AddScoped(sp => sp.GetRequiredService<MongoClient>()
                                     .GetDatabase(mongoDbConfig.DatabaseName)
                                     .GetCollection<ClienteEntity>(mongoDbConfig.DatabaseSettings.CollectionNameCliente));
            return services;
        }
    }
}
