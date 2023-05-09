using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Helpers
{
    public class TokenGenerator
    {
        private static readonly IConfiguration _configuration;
        
        static TokenGenerator()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = config.Build();    
        }

        public static string Generate(IList<Claim> claims, DateTime expiresAt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration.GetSection("TokenHandler").GetValue<string>("Issuer")!,
                Audience = _configuration.GetSection("TokenHandler").GetValue<string>("Audience")!,
                Subject = new ClaimsIdentity(claims),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("TokenHandler").GetValue<string>("SecurityKey")!)),
                    SecurityAlgorithms.HmacSha512Signature
                )
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(securityTokenDescriptor));
        }
    }
}
