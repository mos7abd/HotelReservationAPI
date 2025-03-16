using AutoMapper;
using HotelReservationAPI.Dtos.Users;
using HotelReservationAPI.Models;
using HotelReservationAPI.ViewModels.Users;

namespace HotelReservationAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUserDto>();

            CreateMap<AddUserViewModel, AddUserDto>();
            CreateMap<AddUserDto, User>();


            CreateMap<UpdateUserViewModel, UpdateUserDto>();
            CreateMap<UpdateUserDto, User>();

        }
    }
}
