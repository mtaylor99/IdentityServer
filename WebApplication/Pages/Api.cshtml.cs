using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;

namespace WebApplication.Pages
{
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

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await HttpContext.GetTokenAsync("access_token"));

            Data = await httpClient.GetStringAsync("https://localhost:5003/WeatherForecast");
        }
    }
}
