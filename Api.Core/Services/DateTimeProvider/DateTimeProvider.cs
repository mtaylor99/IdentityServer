using System.Diagnostics.CodeAnalysis;

namespace Api.Core.Services.DateTimeProvider;

[ExcludeFromCodeCoverage]
internal class DateTimeProvider : IDateTimeProvider
{
    public DateTime GetUtcNow()
    {
        return DateTime.UtcNow;
    }
}