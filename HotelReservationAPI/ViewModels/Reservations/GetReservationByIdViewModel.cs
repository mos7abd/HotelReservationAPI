using HotelReservationAPI.Models;

namespace HotelReservationAPI.ViewModels.Reservations
{
    public record GetReservationByIdViewModel
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime BookingDateTime { get; set; }
        public TimeSpan Duration => CheckOut - CheckIn;
        public ReservationStatus Status { get; set; }
        public int RoomId { get; set; }
    }
}
