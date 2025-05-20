namespace TemplateMarket.Domain.Roles;

public static class Roles
{
    public static class Group
    {
        public const string Update = "group:update";
        public const string Read = "group:read";
    }

    public static class Product
    {
        public const string Update = "product:update";
        public const string Read = "product:read";
    }

    public static class Role
    {
        public const string Update = "role:update";
        public const string Read = "role:read";
    }

    public static class UserGroup
    {
        public const string Update = "user-group:update";
        public const string Read = "user-group:read";
    }

    public static class UserCompanyGroup
    {
        public const string Update = "user-company-group:update";
        public const string Read = "user-company-group:read";
    }

    public static class UserCompany
    {
        public const string Update = "user-company:update";
        public const string Read = "user-company:read";
    }

    public static class GroupTemplate
    {
        public const string Update = "group-template:update";
        public const string Read = "group-template:read";
    }
}
