namespace TemplateMarket.Application.Common.Exceptions;

public class AlreadyExistsException : Exception
{
    public AlreadyExistsException(string name)
        : base($"{name} alread existis.") { }
}
