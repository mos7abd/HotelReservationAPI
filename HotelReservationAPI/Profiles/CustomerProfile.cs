using AutoMapper;
using HotelReservationAPI.Models;

namespace HotelReservationAPI.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Stripe.Customer, StripeCustomer>().ReverseMap();
          
        }

    }
}
