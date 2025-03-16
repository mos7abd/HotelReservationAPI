using HotelReservationAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HotelReservationAPI.Configurations
{
    public static class AuthenticationConfigration
    {
        public static IServiceCollection AddAuthenticationConfigration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.SecretKey)),
                        ValidIssuer = "HotelReservation-API",
                        ValidAudience = "HotelReservation-Front",
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,


                    };
                });
            return services;
        }


    }
}
