using Gql;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Validation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


// Register openiddict
builder.Services.AddOpenIddict()
  .AddValidation(options =>
  {
      options.SetIssuer("TODO: place url");
      options.AddAudiences("resource server id");

      options.UseIntrospection()
        .SetClientId("SetClientId")
        .SetClientSecret("key");

      options.UseSystemNetHttp();


      options.UseAspNetCore();
  });


builder.Services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
builder.Services.AddAuthorization();

builder.Services.AddGraphQLServer()
  .AddAuthorization()
  .AddQueryType<Query>();

var app = builder.Build();

app.UseRouting();

app.UseHttpsRedirection();


app.UseAuthorization();
app.UseAuthentication();

app.MapGraphQL();

app.Run();
