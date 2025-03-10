﻿using HotelReservationAPI.Profiles;

namespace HotelReservationAPI.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(RoomProfile).Assembly);
            services.AddAutoMapper(typeof(ReservationProfile).Assembly);

            return services;
        }
    }
}
