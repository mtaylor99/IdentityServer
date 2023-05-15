namespace Api.Core.Extensions;

public static class StringExtensions
{
    public static string ToLowerFirstCharacter(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }

        return char.ToLower(value[0]) + value.Substring(1);
    }
}