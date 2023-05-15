using Microsoft.Extensions.Logging;
using Api.Core.Data.Repository.Exceptions;

namespace Api.Core.Data.Repository.Extensions;

internal static class RepositoryLoggerExtensions
{
    public static ILogger<THandler> LogExecutingStoredProcedure<THandler>(this ILogger<THandler> logger,
        string storedProcedureName)
    {
        logger.LogDebug("Executing stored procedure: {SpName}", storedProcedureName);

        return logger;
    }

    public static ILogger<THandler> LogStoredProcedureFailed<THandler>(this ILogger<THandler> logger,
        StoredProcedureCallFailedException exception)
    {
        logger.LogError(exception, "Stored procedure {SpName} execution failed with parameters: {SpParameters}.",
            exception.ProcedureName, exception.Parameters);

        return logger;
    }
}