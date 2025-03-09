using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace HotelReservationAPI.Configurations
{
    public static class FluentValidationConfigration
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services, Assembly assembly)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(assembly);
            return services;
        }
    }
}
