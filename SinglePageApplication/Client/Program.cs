using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SinglePageApplication;
using SinglePageApplication.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("Api", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:5003");
}).AddHttpMessageHandler<ApiAuthorizationMessageHandler>();

builder.Services.AddOidcAuthentication(options =>
{
    options.ProviderOptions.Authority = "https://localhost:5001"; //AUTHENTICATION__AUTHORITY
    options.ProviderOptions.ClientId = "9f35adbd-8db7-4a0f-aeec-ee22594e1a96"; //AUTHENTICATION__CLIENTID
    options.ProviderOptions.ResponseType = "code";
    options.ProviderOptions.DefaultScopes.Add("https://localhost:5003/api");
});

builder.Services.AddScoped<ApiAuthorizationMessageHandler>();

await builder.Build().RunAsync();