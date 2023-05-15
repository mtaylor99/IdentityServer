using System.Data;
using Dapper;

namespace Api.Data;

public class DbConnectionWrapper : IDbConnectionWrapper
{
    private readonly IDbConnection _dbConnection;

    public DbConnectionWrapper(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IReadOnlyCollection<T>> QueryAsync<T>(string sprocName, object parameters = null)
    {
        var results =
            await _dbConnection.QueryAsync<T>(sprocName, parameters, commandType: CommandType.StoredProcedure);
        return results.ToArray();
    }

    public async Task ExecuteAsync(string sprocName, object parameters = null)
    {
        await _dbConnection.ExecuteAsync(sprocName, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<T> QuerySingleAsync<T>(string sprocName, object parameters = null)
    {
        return await _dbConnection.QuerySingleAsync<T>(sprocName, parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<T> QuerySingleOrDefaultAsync<T>(string sprocName, object parameters = null)
    {
        return await _dbConnection.QuerySingleOrDefaultAsync<T>(sprocName, parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<IReadOnlyCollection<T>> QueryAsync<T1, T2, T>(string sprocName, Func<T1, T2, T> map,
        object parameters = null)
    {
        var results =
            await _dbConnection.QueryAsync(sprocName, map, parameters, commandType: CommandType.StoredProcedure);
        return results.ToArray();
    }

    public async Task<IReadOnlyCollection<T>> QueryAsync<T1, T2, T3, T>(string sprocName, Func<T1, T2, T3, T> map,
        object parameters = null)
    {
        var results =
            await _dbConnection.QueryAsync(sprocName, map, parameters, commandType: CommandType.StoredProcedure);
        return results.ToArray();
    }

    public async Task<IReadOnlyCollection<T>> QueryAsync<T1, T2, T3, T4, T>(string sprocName,
        Func<T1, T2, T3, T4, T> map, object parameters = null)
    {
        var results =
            await _dbConnection.QueryAsync(sprocName, map, parameters, commandType: CommandType.StoredProcedure);
        return results.ToArray();
    }

    public async Task<IReadOnlyCollection<T>> QueryAsync<T1, T2, T3, T4, T5, T>(string sprocName,
        Func<T1, T2, T3, T4, T5, T> map, object parameters = null)
    {
        var results =
            await _dbConnection.QueryAsync(sprocName, map, parameters, commandType: CommandType.StoredProcedure);

        return results.ToArray();
    }

    public async Task<IReadOnlyCollection<T>> QueryAsync<T1, T2, T3, T4, T5, T6, T>(string sprocName,
        Func<T1, T2, T3, T4, T5, T6, T> map, object parameters = null)
    {
        var results =
            await _dbConnection.QueryAsync(sprocName, map, parameters, commandType: CommandType.StoredProcedure);
        return results.ToArray();
    }

    public async Task<IReadOnlyCollection<T>> QueryAsync<T1, T2, T3, T4, T5, T6, T7, T>(string sprocName,
        Func<T1, T2, T3, T4, T5, T6, T7, T> map, object parameters = null)
    {
        var results =
            await _dbConnection.QueryAsync(sprocName, map, parameters, commandType: CommandType.StoredProcedure);
        return results.ToArray();
    }

    public async Task<T> QueryMultipleAsync<T>(string sprocName, Func<SqlMapper.GridReader, Task<T>> mapResult,
        object parameters = null)
    {
        var result =
            await _dbConnection.QueryMultipleAsync(sprocName, parameters, commandType: CommandType.StoredProcedure);
        return await mapResult(result);
    }

    public async Task<IReadOnlyCollection<T>> QueryAsync<T>(string sprocName, Type[] types, Func<object[], T> map, object parameters)
    {
        var result = await _dbConnection.QueryAsync(sprocName, types, map, parameters, commandType: CommandType.StoredProcedure);
        return result.ToArray();
    }
}