using HotelReservationAPI.Models;

namespace HotelReservationAPI.Dtos.Reservations
{
    public record GetReservationIdDto
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime BookingDateTime { get; set; }
        public TimeSpan Duration => CheckOut - CheckIn;
        public ReservationStatus Status { get; set; }
        public int RoomId { get; set; }
    }
}
