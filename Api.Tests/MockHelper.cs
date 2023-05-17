using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace Api.Tests;

internal static class MockHelpers
{
    public static Mock<IOptions<TOptions>> CreateMockOptions<TOptions>(TOptions options)
        where TOptions : class
    {
        var mock = new Mock<IOptions<TOptions>>(MockBehavior.Strict);

        mock.Setup(o => o.Value)
            .Returns(options)
            .Verifiable();

        return mock;
    }

    public static Mock<ILogger<T>> CreateMockLogger<T>()
    {
        var mock = new Mock<ILogger<T>>(MockBehavior.Loose);

        return mock;
    }

    public static Mock<ILoggerFactory> CreateMockLoggerFactory<T>()
    {
        var mockFactory = new Mock<ILoggerFactory>(MockBehavior.Strict);
        var mockLogger = CreateMockLogger<T>();

        mockFactory.Setup(x => x.CreateLogger(typeof(T).FullName))
            .Returns(mockLogger.Object);

        return mockFactory;
    }
}