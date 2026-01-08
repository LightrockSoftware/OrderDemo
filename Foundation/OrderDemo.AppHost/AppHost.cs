var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres").AddDatabase("orderingdb");

var api = builder.AddProject<Projects.Ordering_Api>("ordering-api").WithReference(postgres).WaitFor(postgres);

builder.AddProject<Projects.Ordering_Blazor>("ordering-blazor").WithReference(api);

builder.Build().Run();
