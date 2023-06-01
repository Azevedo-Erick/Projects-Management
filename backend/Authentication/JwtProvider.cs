using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectsManagement.Models;
using ProjectsManagement.Providers;

namespace ProjectsManagement.Authentication;

public sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;

    public JwtProvider(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string Generate(Person person)
    {
        var claims = new Claim[]{
            new Claim(JwtRegisteredClaimNames.Sub, person.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, person.Email),
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.SecretKey)
            ),
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
         _options.Issuer,
         _options.Audience,
         claims,
         null,
         DateTime.UtcNow.AddHours(1),
         signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
