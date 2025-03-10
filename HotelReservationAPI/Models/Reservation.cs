namespace HotelReservationAPI.Models
{
    public class Reservation : BaseModel
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime BookingDateTime { get; set; } = DateTime.UtcNow;
        public TimeSpan Duration => CheckOut - CheckIn;
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
        public DateTime? CanceledAt { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
