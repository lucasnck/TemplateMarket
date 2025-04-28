using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using TemplateMarket.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;


public class JwtTokenGenerator(IConfiguration _config) : IJwtTokenGenerator
{
    public string GenerateToken(User user)
    {
        var keyConfig = _config["Jwt:Key"]!;

        var key = new SymmetricSecurityKey(
            Convert.FromBase64String(keyConfig)
        );
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
        };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
