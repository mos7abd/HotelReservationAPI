namespace HotelReservationAPI.Dtos.Users
{
    public record GetUserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}
