using HotelReservationAPI.Dtos.Users;
using HotelReservationAPI.Helper;
using HotelReservationAPI.Models;
using HotelReservationAPI.Repositoried;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationAPI.Services
{
    public class UserService
    {
        private readonly GeneralRepository<User> _userRepository;
        public UserService()
        {
            _userRepository = new GeneralRepository<User>();
        }
        public async Task<GetUserDto?> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.Get(u => u.Email == email).FirstOrDefaultAsync();
            return user?.Map<GetUserDto?>();

        }


        public async Task<GetUserDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIDAsync(id);
            return user?.Map<GetUserDto?>();
        }

        public async Task<bool> IsEmailExist(string email)
        {
            return await _userRepository.Get(u => u.Email == email).AnyAsync();
        }

        public async Task<bool> IsUserExist(int id)
        {
            return await _userRepository.Get(u => u.ID == id).AnyAsync();
        }


        public async Task<int> AddAsync(AddUserDto addUserDto)
        {
            var newUser = addUserDto.Map<User>();
            var newUserId = await _userRepository.AddAsync(newUser);
            return newUserId;
        }
        public void UpdateUser(UpdateUserDto updateUserDto)
        {
            var updatedUser = updateUserDto.Map<User>();
            _userRepository.UpdateInclude(updatedUser, nameof(User.FristName),
               nameof(User.LastName), nameof(User.Email), nameof(User.Address));

        }


        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }


    }
}
