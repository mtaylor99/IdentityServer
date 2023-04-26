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
    options.ProviderOptions.ClientId = "3049889f-7514-4e8d-8c70-e78123cea6cb"; //AUTHENTICATION__CLIENTID
    options.ProviderOptions.ResponseType = "code";
    options.ProviderOptions.DefaultScopes.Add("https://localhost:5003/api");
});

builder.Services.AddScoped<ApiAuthorizationMessageHandler>();

await builder.Build().RunAsync();