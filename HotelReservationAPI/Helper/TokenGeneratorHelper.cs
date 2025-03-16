using HotelReservationAPI.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelReservationAPI.Helper
{
    public class TokenGeneratorHelper
    {
        public static string GenerateToken(string userId, string name, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", userId),
                    new Claim(ClaimTypes.Role, role),
                    new Claim(ClaimTypes.Name, name)
                }),
                Expires = DateTime.Now.AddHours(1),
                Issuer = "HotelReservation-API",
                Audience = "HotelReservation-Front",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.SecretKey)),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
