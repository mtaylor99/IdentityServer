using Api.Core.Exceptions;
using Api.Core.Models.Error;

namespace Api.Core.Services;

internal static class RequestValidator
{
    public delegate void AddPropertyErrorFunc(string propertyName, string errorMessage = null);

    public static async Task ValidateOrThrowAsync<TRequest>(
        TRequest request,
        Func<TRequest, AddPropertyErrorFunc, Task> validatorFunc)
    {
        var errors = new List<PropertyError>();

        await validatorFunc(request,
            (propertyName, errorMessage) => AddPropertyError(errors, propertyName, errorMessage));

        if (errors.Any())
            throw BuildApiException(errors);
    }

    private static void AddPropertyError(ICollection<PropertyError> errors, string propertyName,
        string errorMessage = null)
    {
        errors.Add(BuildPropertyError(propertyName, errorMessage));
    }

    private static PropertyError BuildPropertyError(string propertyName, string errorMessage)
    {
        return new PropertyError
        {
            PropertyName = propertyName,
            ErrorMessage = errorMessage ?? $"Invalid {propertyName}"
        };
    }

    private static ApiException BuildApiException(IEnumerable<PropertyError> propertyErrors)
    {
        return new ApiException(new TransactionErrorResponse
        {
            PropertyErrors = propertyErrors
        });
    }
}