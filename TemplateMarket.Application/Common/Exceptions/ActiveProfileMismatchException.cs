using TemplateMarket.Application.Responses;

public class ActiveProfileMismatchException : Exception
{
    public AvailableProfileResponse? Current { get; }
    public string RequestedCompanyIdentification { get; }

    public ActiveProfileMismatchException(AvailableProfileResponse current, string? requested)
        : base($"Requested profile ({requested?.ToString() ?? "personal"}) does not match the active profile ({current?.ToString() ?? "personal"}).")
    {
        Current = current;
        RequestedCompanyIdentification = requested;
    }
}
