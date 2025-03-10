namespace HotelReservationAPI.Dtos.Reservations
{
    public record UpdateReservationDto
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int RoomId { get; set; }

    }
}
