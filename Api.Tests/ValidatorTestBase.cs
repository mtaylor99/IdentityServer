using AutoFixture;
using FluentValidation.Results;

namespace Api.Tests;

public abstract class ValidatorTestBase : TestBase
{
    protected ValidatorTestBase()
    {
    }

    protected ValidatorTestBase(IFixture fixture)
        : base(fixture)
    {
    }

    protected static void AssertSingleValidationFailure(ValidationResult result, string propertyName)
    {
        Assert.False(result.IsValid);
        var validationFailure = Assert.Single(result.Errors);
        Assert.Equal(propertyName, validationFailure.PropertyName);
    }
}