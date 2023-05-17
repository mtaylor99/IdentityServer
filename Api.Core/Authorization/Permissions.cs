namespace Api.Core.Authorization;

public static class Permissions
{
    public const string ClaimName = "api_permissions";

    public static class Administration
    {
        public const string Roles = "admin.roles";
        public const string Users = "admin.users";
    }
}