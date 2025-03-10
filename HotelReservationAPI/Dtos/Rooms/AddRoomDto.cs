using HotelReservationAPI.Models;

namespace HotelReservationAPI.Dtos.Rooms
{
    public record AddRoomDto
    {
        public RoomType Type { get; set; }
        public int Price { get; set; }
        public int Number { get; set; }
        public RoomStatus Status { get; set; }
    }
}
