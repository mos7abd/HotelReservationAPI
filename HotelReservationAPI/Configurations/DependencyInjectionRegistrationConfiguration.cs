using HotelReservationAPI.Data;
using HotelReservationAPI.Middlewares;
using HotelReservationAPI.Services;
using Stripe;

namespace HotelReservationAPI.Configurations
{
    public static class DependencyInjectionRegistrationConfiguration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<RoomService>();
            services.AddScoped<Context>();
            services.AddScoped<ProductService>();
            services.AddScoped<StripeService>();
            services.AddScoped<PriceService>();

            services.AddScoped<GlobalErrorHandlerMiddleware>();
            services.AddScoped<TransactionMiddleware>();

            return services;
        }

    }
}
