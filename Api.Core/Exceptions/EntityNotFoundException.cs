using Api.Core.Models.Error;
using System.Diagnostics.CodeAnalysis;

namespace Api.Core.Exceptions;

[ExcludeFromCodeCoverage]
public class EntityNotFoundException : Exception
{
    public EntityNotFoundException()
    {
    }

    public EntityNotFoundException(string message)
    {
        ErrorResponse = new TransactionErrorResponse
        {
            GeneralError = new GeneralError
            {
                ErrorMessage = message
            }
        };
    }

    public TransactionErrorResponse ErrorResponse { get; set; }
}