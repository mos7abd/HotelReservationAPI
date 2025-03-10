namespace HotelReservationAPI.ViewModels.Reservations
{
    public record AddReservationViewModel
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
    }
}
