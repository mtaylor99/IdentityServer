using Api.Core.Models.Error;
using System.Diagnostics.CodeAnalysis;

namespace Api.Core.Exceptions;

[ExcludeFromCodeCoverage]
public class InvalidFileException : Exception
{
    public InvalidFileException(string message)
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