using DAL.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace mon_gestionnaire_de_repas_api.Tools
{
    public class TokenManager
    {
        public static string Key = "T93827465J9nQ2w3e4r5t6y7u8i9o0jhse";

        //Package Nugget Microsoft.AspNetCore.Authentication.JwtBearer
        public string GeneretedToken(User user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Pseudo),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.IsAdmin == true ? "admin" : "user"),
                new Claim("id", user.UserId.ToString()),
            };

            JwtSecurityToken jwt = new JwtSecurityToken(claims: claims, signingCredentials: credentials, expires: DateTime.Now.AddHours(12));
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(jwt);
        }
    }
}
