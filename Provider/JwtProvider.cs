using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Demo.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Demo.Provider
{
    public class JwtProvider : IJwtProvider
    {
        JwtOptions _options;
        IConfiguration _configuration;
        public JwtProvider(IConfiguration configuration)
        {
            _options = new JwtOptions();
            _configuration = configuration;
            
          _options.SigningKey = _configuration.GetValue<string>("JwtOptions:SigningKey");
          _options.Audience = _configuration.GetValue<string>("JwtOptions:Audience");
          _options.Issuer = _configuration.GetValue<string>("JwtOptions:Issuer");
        }

        public string Generate(User user)
        {
           var claims = new Claim[]
           {
                new (ClaimTypes.Email, user?.Email ?? string.Empty),
                new (ClaimTypes.Name, user?.FirstName ?? string.Empty),
                new (ClaimTypes.Role, user?.Role ?? string.Empty)
           };

           var SigningKey = new SigningCredentials(
            new SymmetricSecurityKey (
                Encoding.UTF8.GetBytes(_options?.SigningKey ?? string.Empty)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _options?.Issuer,
                _options?.Audience,
                claims,
                null,
                DateTime.UtcNow.AddHours(2),
                SigningKey);

            string tokenValue = new JwtSecurityTokenHandler()
            .WriteToken(token);

            return tokenValue;         
           
        }
    }
}