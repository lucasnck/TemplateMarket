namespace TemplateMarket.Application.Common.Exceptions;

public class AlreadExistsException : Exception
{
    public AlreadExistsException(string name)
        : base($"{name} alread existis.") { }
}
