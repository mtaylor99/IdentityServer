using System.Diagnostics.CodeAnalysis;
using Api.Core.Extensions;
using Api.Core.Models.Error;

namespace Api.Core.Data.Repository.Extensions;

[ExcludeFromCodeCoverage]
public class ApiException : Exception
{
    public ApiException()
    {
        ErrorResponse = new TransactionErrorResponse();
    }

    public ApiException(string message)
        : base(message)
    {
        ErrorResponse = BuildErrorResponse(message);
    }

    public ApiException(string message, Exception innerException)
        : base(message, innerException)
    {
        ErrorResponse = BuildErrorResponse(message);
    }

    public ApiException(string property, string message)
    {
        property = property.ToLowerFirstCharacter();
        ErrorResponse = new TransactionErrorResponse
        {
            PropertyErrors = new[]
            {
                new PropertyError { ErrorMessage = message, PropertyName = property }
            }
        };
    }

    public ApiException(TransactionErrorResponse errorResponse)
    {
        ErrorResponse = errorResponse;
    }

    public TransactionErrorResponse ErrorResponse { get; }

    private static TransactionErrorResponse BuildErrorResponse(string message)
    {
        return new TransactionErrorResponse
        {
            GeneralError = new GeneralError
            {
                ErrorMessage = message
            }
        };
    }
}