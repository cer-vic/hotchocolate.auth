using Gql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();


builder.Services.AddGraphQLServer()
  .AddAuthorization()
  .AddQueryType<Query>();

var app = builder.Build();

app.UseRouting();

app.UseAuthorization();
app.UseAuthorization();

app.MapGraphQL();

app.Run();
