var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.ToDoAppForKC3_ApiService>("apiservice");

builder.AddProject<Projects.ToDoAppForKC3_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
