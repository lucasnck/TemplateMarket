namespace TemplateMarket.Application.Common.Validators;

public static class CpfValidator
{
    public static bool IsValid(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        if (cpf.Length != 11 || cpf.All(d => d == cpf[0]))
            return false;

        var numbers = cpf.Select(c => int.Parse(c.ToString())).ToArray();

        for (int j = 9; j < 11; j++)
        {
            int sum = 0;
            for (int i = 0; i < j; i++)
                sum += numbers[i] * (j + 1 - i);

            int remainder = sum % 11;
            int digit = remainder < 2 ? 0 : 11 - remainder;

            if (numbers[j] != digit)
                return false;
        }

        return true;
    }
}
