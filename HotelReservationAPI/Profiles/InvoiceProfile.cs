using AutoMapper;
using HotelReservationAPI.Dtos.Invoice;

namespace HotelReservationAPI.Profiles
{
    public class InvoiceProfile : Profile
    {
      
            public InvoiceProfile()
            {
                CreateMap<Stripe.Invoice, InvoiceDTO>().ReverseMap();

            }

        
    }
}
