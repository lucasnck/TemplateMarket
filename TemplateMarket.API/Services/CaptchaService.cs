using System.Text.Json;

public class CaptchaService
{
    private readonly HttpClient _http;
    private readonly IConfiguration _config;

    public CaptchaService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _config = config;
    }

    public async Task<bool> ValidateTokenAsync(string token)
    {
        var secret = _config["Recaptcha:Secret"];
        var response = await _http.PostAsync(
            $"https://www.google.com/recaptcha/api/siteverify?secret={secret}&response={token}",
            null
        );

        if (!response.IsSuccessStatusCode)
            return false;

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<RecaptchaResponse>(json);
        return result?.Success == true && (result.Score == null || result.Score >= 0.5f);
    }
}

public class RecaptchaResponse
{
    public bool Success { get; set; }
    public float? Score { get; set; }
    public List<string> ErrorCodes { get; set; }
}
