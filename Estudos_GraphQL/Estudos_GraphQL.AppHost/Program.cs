var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Estudos_GraphQL>("estudos-graphql");

builder.Build().Run();
