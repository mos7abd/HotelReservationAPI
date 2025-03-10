namespace HotelReservationAPI.Dtos.Reservations
{
    public record AddReservationDto
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }

    }
}
