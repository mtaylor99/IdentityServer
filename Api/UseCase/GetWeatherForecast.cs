using MediatR;

namespace Api.UseCase
{
    internal class GetWeatherForecast : IRequestHandler<GetWeatherForecastRequest, GetWeatherForecastResponse>
    {
        public GetWeatherForecast()
        {

        }

        public async Task<GetWeatherForecastResponse> Handle(GetWeatherForecastRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return new GetWeatherForecastResponse();
        }
    }

    public class GetWeatherForecastRequest : IRequest<GetWeatherForecastResponse>
    {
        public string Postcode { get; set; }
    }

    public class GetWeatherForecastResponse
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
