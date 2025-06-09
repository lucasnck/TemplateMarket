using System.Text.RegularExpressions;

namespace TemplateMarket.Application.Common.Validators;

public static class PhoneValidator
{
    private static readonly Regex PhoneRegex = new(@"^\+?[1-9]\d{7,14}$", RegexOptions.Compiled);

    public static bool IsValid(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return false;

        // Remove espaços, hífens e parênteses
        var normalized = Regex.Replace(phone, @"[\s\-\(\)]", "");

        return PhoneRegex.IsMatch(normalized);
    }
}
