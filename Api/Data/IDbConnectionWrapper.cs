using Dapper;

namespace Api.Data;

public interface IDbConnectionWrapper
{
    // TODO: Replace IReadOnlyCollections with IEnumerables

    Task<IReadOnlyCollection<T>> QueryAsync<T>(string sprocName, object parameters = null);

    Task ExecuteAsync(string sprocName, object parameters = null);

    Task<T> QuerySingleAsync<T>(string sprocName, object parameters = null);

    Task<T> QuerySingleOrDefaultAsync<T>(string sprocName, object parameters = null);

    Task<IReadOnlyCollection<T>> QueryAsync<T1, T2, T>(string sprocName, Func<T1, T2, T> map, object parameters = null);

    Task<IReadOnlyCollection<T>> QueryAsync<T1, T2, T3, T>(string sprocName, Func<T1, T2, T3, T> map,
        object parameters = null);

    Task<IReadOnlyCollection<T>> QueryAsync<T1, T2, T3, T4, T>(string sprocName, Func<T1, T2, T3, T4, T> map,
        object parameters = null);

    Task<IReadOnlyCollection<T>> QueryAsync<T1, T2, T3, T4, T5, T>(string sprocName, Func<T1, T2, T3, T4, T5, T> map,
        object parameters = null);

    Task<IReadOnlyCollection<T>> QueryAsync<T1, T2, T3, T4, T5, T6, T>(string sprocName,
        Func<T1, T2, T3, T4, T5, T6, T> map, object parameters = null);

    Task<IReadOnlyCollection<T>> QueryAsync<T1, T2, T3, T4, T5, T6, T7, T>(string sprocName,
        Func<T1, T2, T3, T4, T5, T6, T7, T> map, object parameters = null);

    Task<T> QueryMultipleAsync<T>(string sprocName, Func<SqlMapper.GridReader, Task<T>> mapResult,
        object parameters = null);

    Task<IReadOnlyCollection<T>> QueryAsync<T>(string sprocName, Type[] types, Func<object[], T> map, object parameters);
}