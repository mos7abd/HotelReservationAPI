using HotelReservationAPI.Models;

namespace HotelReservationAPI.Dtos.Rooms
{
    public record UpdateRoomDto
    {
        public int ID { get; set; }
        public int Price { get; set; }
        public RoomStatus Status { get; set; }
    }
}
