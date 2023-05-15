namespace Api.Core.Models.Error;

public class TransactionErrorResponse
{
    public IEnumerable<PropertyError> PropertyErrors { get; set; }
    public GeneralError GeneralError { get; set; }
}