using Api.Data.StoredProcedureResults;

namespace Api.Data.Repository.Interfaces;

public interface IApplicationRepository
{
    Task<GetClientsResult> GetClients();
}