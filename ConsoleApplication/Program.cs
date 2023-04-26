using System.Net.Http.Headers;
using IdentityModel.Client;

using var identityServerHttpClient = new HttpClient
{
    BaseAddress = new Uri("https://localhost:5001") //AUTHENTICATION__AUTHORITY
};

var discoveryDocumentResponse = await identityServerHttpClient.GetDiscoveryDocumentAsync();

Console.WriteLine(discoveryDocumentResponse.TokenEndpoint);

var tokenResponse = await identityServerHttpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
{
    Address = discoveryDocumentResponse.TokenEndpoint,
    ClientId = "bff7411d-668c-4f7f-8a6c-6c047deda847", //AUTHENTICATION__CLIENTID
    ClientSecret = "secret", //AUTHENTICATION__CLIENTSECRET
    Scope = "https://localhost:5003/api"
});

Console.WriteLine(tokenResponse.AccessToken);

using var httpClient = new HttpClient
{
    DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken)}
};

var weatherForecast = await httpClient.GetStringAsync("https://localhost:5003/WeatherForecast");

Console.WriteLine(weatherForecast);