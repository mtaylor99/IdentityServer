using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Api.Core.Data;
using Api.Core.Data.Repository;
using Api.Core.Data.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Api.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCoreServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("IdentityServer")
                               ?? throw new InvalidOperationException(
                                   "The DB_CONNSTRING configuration value has not been specified");
        services.AddScoped<IDbConnection>(e => new SqlConnection(connectionString));
        services.AddScoped<IDbConnectionWrapper, DbConnectionWrapper>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<IApplicationRepository, ApplicationRepository>();
    }
}