using System.Diagnostics.CodeAnalysis;

namespace Api.Core.Authorization;

[ExcludeFromCodeCoverage]
public class ResourceUnauthorizedException : Exception
{
    public ResourceUnauthorizedException()
    {
    }

    public ResourceUnauthorizedException(string message)
        : base(message)
    {
    }

    public ResourceUnauthorizedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ResourceUnauthorizedException(string message, object resource)
        : this(message)
    {
        Resource = resource;
    }

    public object Resource { get; }
}