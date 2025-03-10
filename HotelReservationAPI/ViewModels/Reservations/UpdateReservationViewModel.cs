namespace HotelReservationAPI.ViewModels.Reservations
{
    public record UpdateReservationViewModel
    {
        public int ID { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int RoomId { get; set; }
    }
}
