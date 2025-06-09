namespace TemplateMarket.Application.Common.Validators;

public static class PasswordValidator
{
    public static bool IsValid(string password)
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            return false;

        bool hasUpperCase = password.Any(char.IsUpper);
        bool hasDigit = password.Any(char.IsDigit);

        return hasUpperCase && hasDigit;
    }
}
