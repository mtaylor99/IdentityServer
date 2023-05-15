using Api.Data.Repository.Extensions;
using Api.Data.Repository.Interfaces;
using Api.Data.StoredProcedureResults;

namespace Api.Data.Repository;

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
