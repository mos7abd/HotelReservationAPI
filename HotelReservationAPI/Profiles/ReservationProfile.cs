using AutoMapper;
using HotelReservationAPI.Dtos.Reservations;
using HotelReservationAPI.Models;
using HotelReservationAPI.ViewModels.Reservations;

namespace HotelReservationAPI.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<AddReservationDto, Reservation>();

            CreateMap<AddReservationViewModel, AddReservationDto>();

        }
    }
}
