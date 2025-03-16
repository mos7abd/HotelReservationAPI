namespace HotelReservationAPI.Dtos.Users
{
    public record GetUserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
