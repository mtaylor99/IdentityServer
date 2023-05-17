using Microsoft.AspNetCore.Authorization;

namespace Api.Authorization;

internal class PermissionAuthorizeAttribute : AuthorizeAttribute
{
    private const string PolicyPrefix = "permission.";

    public PermissionAuthorizeAttribute(string permission)
    {
        if (string.IsNullOrEmpty(permission)) throw new ArgumentNullException(nameof(permission));

        Permission = permission;
    }


    public string Permission
    {
        get => Policy![PolicyPrefix.Length..];
        set => Policy = $"{PolicyPrefix}{value.ToLower()}";
    }
}