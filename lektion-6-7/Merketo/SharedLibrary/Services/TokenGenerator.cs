using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SharedLibrary.Services;

public class TokenGenerator
{
    private static readonly IConfiguration configuration;

    static TokenGenerator()
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        configuration = builder.Build();
    }

    public static string Generate(IList<Claim> claims, DateTime expiresAt)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = configuration.GetSection("TokenValidation").GetValue<string>("Issuer")!,
            Audience = configuration.GetSection("TokenValidation").GetValue<string>("Audience")!,
            Subject = new ClaimsIdentity(claims),
            Expires = expiresAt,
            SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration.GetSection("TokenValidation").GetValue<string>("SecretKey")!)),
                SecurityAlgorithms.HmacSha512Signature
            )
        };

        return tokenHandler.WriteToken(tokenHandler.CreateToken(securityTokenDescriptor));
    }
}
