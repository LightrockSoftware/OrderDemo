var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres");
var orderingDatabase = postgres.AddDatabase("orderingdb");

builder.AddProject<Projects.Ordering_Api>("ordering-api").WithReference(postgres).WaitFor(orderingDatabase);

builder.AddProject<Projects.Ordering_Blazor>("ordering-blazor");

builder.Build().Run();
