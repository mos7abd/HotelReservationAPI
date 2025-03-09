using HotelReservationAPI.Services;

namespace HotelReservationAPI.Configurations
{
    public static class DependencyInjectionRegistrationConfiguration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<RoomService>();



            return services;
        }

    }
}
