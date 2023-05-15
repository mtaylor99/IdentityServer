using Microsoft.Extensions.Logging;
using Api.Core.Data.Repository.Extensions;
using Api.Core.Data.Repository.Interfaces;
using Api.Core.Data.StoredProcedureResults;

namespace Api.Core.Data.Repository;

public class ApplicationRepository : IApplicationRepository
{
    private readonly IDbConnectionWrapper _connection;
    private readonly ILogger<ApplicationRepository> _logger;

    public ApplicationRepository(IDbConnectionWrapper connection, ILogger<ApplicationRepository> logger)
    {
        _connection = connection;
        _logger = logger;
    }

    public async Task<GetClientsResult> GetClients()
    {
        _logger.LogExecutingStoredProcedure(nameof(GetClients));

        return await _connection.QuerySingleOrDefaultAsync<GetClientsResult>(nameof(GetClients));
    }
}
