using MediatR;
using Api.Core.Data.Repository.Interfaces;

namespace Api.Core.UseCase;

public class GetWeatherForecast : IRequestHandler<GetWeatherForecastRequest, GetWeatherForecastResponse>
{
    private readonly IApplicationRepository _applicationRepository;

    public GetWeatherForecast(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }

    public async Task<GetWeatherForecastResponse> Handle(GetWeatherForecastRequest request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var clients = await _applicationRepository.GetClients();

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

