using Moq;
using Xunit;
using Api.Core.Data.Repository.Interfaces;
using Api.Core.Data.StoredProcedureResults;
using Api.Core.UseCase;

namespace Api.Tests.UseCase;

public class GetWeatherForecastTests : TestBase
{
    private readonly Mock<IApplicationRepository> _applicationRepository;
    private readonly GetWeatherForecast _sut;

    public GetWeatherForecastTests()
    {
        _applicationRepository = new Mock<IApplicationRepository>();
        _sut = new GetWeatherForecast(_applicationRepository.Object);
    }

    [Fact]
    public async Task HandlerReturns_NotNullResult()
    {
        // Arrange
        var request = new GetWeatherForecastRequest { Postcode = "SA15" };
        var clientId = "12345";
        var clientName = "Client Name";
        var temperatureC = 0;
        _applicationRepository
            .Setup(x => x.GetClients())
            .ReturnsAsync(new GetClientsResult()
                {
                    ClientId= clientId,
                    ClientName = clientName
            });

        // Act
        var results = await _sut.Handle(request, CancellationToken.None);

        // Assert
        Assert.NotNull(results);
        Assert.Equal(temperatureC, results?.TemperatureC);
    }
}
