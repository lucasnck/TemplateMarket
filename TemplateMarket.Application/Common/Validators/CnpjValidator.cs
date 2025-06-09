namespace TemplateMarket.Application.Common.Validators;

public static class CnpjValidator
{
    public static bool IsValid(string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
            return false;

        cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

        if (cnpj.Length != 14 || cnpj.All(d => d == cnpj[0]))
            return false;

        var numbers = cnpj.Select(c => int.Parse(c.ToString())).ToArray();

        int[] mult1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] mult2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        int sum = 0;
        for (int i = 0; i < 12; i++)
            sum += numbers[i] * mult1[i];

        int remainder = sum % 11;
        int digit1 = remainder < 2 ? 0 : 11 - remainder;

        if (numbers[12] != digit1)
            return false;

        sum = 0;
        for (int i = 0; i < 13; i++)
            sum += numbers[i] * mult2[i];

        remainder = sum % 11;
        int digit2 = remainder < 2 ? 0 : 11 - remainder;

        return numbers[13] == digit2;
    }
}
