using System.Data;
using Api.Data;
using Api.Data.Repository.Interfaces;
using Api.Data.Repository;
using Microsoft.Data.SqlClient;

namespace Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCoreServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("IdentityServer")
                               ?? throw new InvalidOperationException(
                                   "The DB_CONNSTRING configuration value has not been specified");
        services.AddScoped<IDbConnection>(e => new SqlConnection(connectionString));
        services.AddScoped<IDbConnectionWrapper, DbConnectionWrapper>();

        services.AddScoped<IApplicationRepository, ApplicationRepository>();
    }
}