using Api.Core.Exceptions;
using AutoFixture;

namespace Api.Tests;

public abstract class TestBase
{
    protected IFixture Fixture;

    protected TestBase()
        : this(new Fixture())
    {
    }

    protected TestBase(IFixture fixture)
    {
        Fixture = fixture;
    }

    protected static async Task AssertApiExceptionThrownWithPropertyError(Func<Task> functionCall, string propertyName)
    {
        var result = await Assert.ThrowsAsync<ApiException>(functionCall);

        Assert.Collection(result.ErrorResponse.PropertyErrors,
            pe => Assert.True(propertyName.Equals(pe.PropertyName, StringComparison.OrdinalIgnoreCase)));
    }
}