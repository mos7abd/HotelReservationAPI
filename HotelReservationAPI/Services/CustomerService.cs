using HotelReservationAPI.Dtos.Customers;
using HotelReservationAPI.Helper;
using HotelReservationAPI.Models;
using HotelReservationAPI.Repositoried;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationAPI.Services
{
    public class CustomerService
    {
        private readonly GeneralRepository<Customer> _customerRepository;

        public CustomerService()
        {
            _customerRepository = new GeneralRepository<Customer>();
        }

        public async Task<GetCustomerByIdDto?> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIDAsync(id);
            return customer?.Map<GetCustomerByIdDto?>();
        }

        public async Task<bool> IsCustomerExistAsync(int id)
        {
            return await _customerRepository.Get(c => c.ID == id).AnyAsync();
        }

        public async Task<int> AddAsync(AddCustomerDto addCustomerDto)
        {
            var newCustomer = addCustomerDto.Map<Customer>();
            var newCustomerId = await _customerRepository.AddAsync(newCustomer);
            return newCustomerId;
        }
    }
}
