namespace TemplateMarket.Domain.Common.Errors;

public static class Errors
{
    public static class Entity
    {
        public const string IDENTIFICATION_REQUIRED = "IDENTIFICATION_REQUIRED";
        public const string IDENTIFICATION_INVALID = "IDENTIFICATION_INVALID";
        public const string IDENTIFICATION_NOT_AVAILABLE = "IDENTIFICATION_NOT_AVAILABLE";

        public const string NAME_REQUIRED = "NAME_REQUIRED";
    }

    public static class User
    {
        public const string CANNOT_CREATE_USER = "CANNOT_CREATE_USER";

        public const string EMAIL_REQUIRED = "EMAIL_REQUIRED";
        public const string EMAIL_INVALID = "EMAIL_INVALID";
        public const string EMAIL_NOT_AVAILABLE = "EMAIL_NOT_AVAILABLE";

        public const string PHONE_REQUIRED = "PHONE_REQUIRED";
        public const string PHONE_INVALID = "PHONE_INVALID";
        public const string PHONE_NOT_AVAILABLE = "PHONE_NOT_AVAILABLE";

        public const string PASSWORD_REQUIRED = "PASSWORD_REQUIRED";
        public const string PASSWORD_MIN_LENGHT_6 = "PASSWORD_MIN_LENGHT_6";
        public const string PASSWORD_INVALID = "PASSWORD_INVALID";
    }

    public static class Company
    {
        public const string CANNOT_CREATE_COMPANY = "CANNOT_CREATE_COMPANY";

        public const string EMAIL_REQUIRED = "EMAIL_REQUIRED";
        public const string EMAIL_INVALID = "EMAIL_INVALID";
        public const string EMAIL_NOT_AVAILABLE = "EMAIL_NOT_AVAILABLE";

        public const string PHONE_REQUIRED = "PHONE_REQUIRED";
        public const string PHONE_INVALID = "PHONE_INVALID";
        public const string PHONE_NOT_AVAILABLE = "PHONE_NOT_AVAILABLE";

        public const string PASSWORD_REQUIRED = "PASSWORD_REQUIRED";
        public const string PASSWORD_MIN_LENGHT_6 = "PASSWORD_MIN_LENGHT_6";
        public const string PASSWORD_INVALID = "PASSWORD_INVALID";
    }
}
