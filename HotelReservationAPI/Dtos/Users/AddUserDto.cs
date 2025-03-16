using HotelReservationAPI.Models;

namespace HotelReservationAPI.Dtos.Users
{
    public record AddUserDto
    {
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Role Role { get; set; }
    }
}
