using AutoMapper;
using HotelReservationAPI.Dtos.Customers;
using HotelReservationAPI.Models;

namespace HotelReservationAPI.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, GetCustomerByIdDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.FristName, opt => opt.MapFrom(src => src.User.FristName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.User.Address));

            CreateMap<AddCustomerDto, Customer>();
        }

    }
}
