using HotelReservationAPI.Models;
using HotelReservationAPI.Repositoried;

namespace HotelReservationAPI.Services
{
    public class CustomerService
    {   
        GeneralRepository<Customer> _customerRepo;
        public CustomerService(GeneralRepository<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public string GetCustomerStripeId(string customerEmail)
        {
            return _customerRepo.Get(_customerRepo => _customerRepo.Email == customerEmail).FirstOrDefault().StripeId;
        }
    }
}

