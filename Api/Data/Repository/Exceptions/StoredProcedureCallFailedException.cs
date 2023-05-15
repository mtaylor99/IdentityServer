namespace Api.Data.Repository.Exceptions;

internal class StoredProcedureCallFailedException : Exception
{
    private const string ErrorText = "Stored Procedure Failed";

    public StoredProcedureCallFailedException()
        : base(ErrorText)
    {
    }

    public StoredProcedureCallFailedException(Exception innerException)
        : base(ErrorText, innerException)
    {
    }

    public StoredProcedureCallFailedException(string procedureName)
        : base($"{ErrorText}: {procedureName}")
    {
        ProcedureName = procedureName;
    }

    public StoredProcedureCallFailedException(string procedureName, Exception innerException)
        : base($"{ErrorText}: {procedureName}", innerException)
    {
        ProcedureName = procedureName;
    }

    public StoredProcedureCallFailedException(string procedureName, object parameters)
        : this(procedureName)
    {
        Parameters = parameters;
    }

    public StoredProcedureCallFailedException(string procedureName, object parameters, Exception innerException)
        : this(procedureName, innerException)
    {
        Parameters = parameters;
    }

    public string ProcedureName { get; }
    public object Parameters { get; }
}