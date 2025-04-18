﻿using Estudos_GraphQL.Domain;
using Estudos_GraphQL.Domain.Repositorios;
using Estudos_GraphQL.Infra.GraphQlQueries;
using Estudos_GraphQL.Infra.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Estudos_GraphQL.IoC
{
    public static class AppServiceCollectionExtensions
    {
        public static void ConfigureAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(DomainEntryPoint).Assembly));

            services.AddScoped<ILivroRepository, LivroRepository>();

            services.AddGraphQLServer().AddQueryType<LivroQueryConfiguration>().AddMutationType<LivrosMutationConfiguration>();
        }
    }
}
