using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Drona.AyushmanBharat.API.Factories
{
    public static class JwtTokenGenerator
    {
        public static async Task<string> GenerateJwtToken(string claim)
        {
            //todo : get it from configuration
            string secretKey = "72B35A9B6C1CEE6701D1551E9EA72F21D3A823C22E9FE69122C4AC4071A44471";
            string issuer = "String.Empty.Com";
            string audience = "string.empty.com";

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, claim)
                // Add more claims as needed
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Set token expiration as needed
                signingCredentials: credentials
            );
            var result = await Task.Run(() => new JwtSecurityTokenHandler().WriteToken(token));
            return result;
        }
    }
}
