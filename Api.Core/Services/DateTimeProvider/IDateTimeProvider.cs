namespace Api.Core.Services.DateTimeProvider;

public interface IDateTimeProvider
{
    public DateTime GetUtcNow();
}