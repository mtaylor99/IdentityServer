using Api.Core.Data.StoredProcedureResults;

namespace Api.Core.Data.Repository.Interfaces;

public interface IApplicationRepository
{
    Task<GetClientsResult> GetClients();
}