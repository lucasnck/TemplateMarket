// IJwtTokenGenerator interface
using TemplateMarket.Domain.Entities;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}