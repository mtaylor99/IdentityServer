using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Pages
{
    [Authorize]
    public class ApiModel : PageModel
    {
        public ApiModel(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        public string? Data { get; set; }

        private IHttpClientFactory HttpClientFactory { get; }

        public async Task OnGetAsync()
        {
            using var httpClient = HttpClientFactory.CreateClient();

            var token = await HttpContext.GetTokenAsync("access_token");

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await HttpContext.GetTokenAsync("access_token"));

            Data = await httpClient.GetStringAsync("https://localhost:5003/WeatherForecast");
        }
    }
}
