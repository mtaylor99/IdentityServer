using Dapper;
using Microsoft.Data.SqlClient;
using Moq;
using System.Data;
using static Dapper.SqlMapper;

namespace Api.Tests.Extensions;

internal static class DynamicParametersExtensions
{
    public static DataTable? GetDataTable(this DynamicParameters dynamicParameters, string parameterName)
    {
        var parameter = dynamicParameters.Get<ICustomQueryParameter>(parameterName);

        if (parameter is null)
            return null;

        var sqlParameter = new SqlParameter();
        var mockDbCommand = new Mock<IDbCommand>();
        mockDbCommand.Setup(x => x.CreateParameter())
            .Returns(sqlParameter);

        var mockParameterCollection = new Mock<IDataParameterCollection>();

        mockDbCommand.SetupGet(x => x.Parameters)
            .Returns(mockParameterCollection.Object);

        parameter.AddParameter(mockDbCommand.Object, string.Empty);

        return sqlParameter.Value as DataTable;
    }

    public static IEnumerable<T> GetTableValues<T>(this
        DynamicParameters dynamicParameters, string parameterName)
    {
        var dataTable = dynamicParameters.GetDataTable(parameterName);

        if (dataTable is null) return Enumerable.Empty<T>();

        return dataTable
            .AsEnumerable()
            .Select(row => (T)row["Value"]);
    }
}