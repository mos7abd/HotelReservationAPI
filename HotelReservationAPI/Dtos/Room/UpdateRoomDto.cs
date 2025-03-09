using HotelReservationAPI.Enum;

namespace HotelReservationAPI.Dtos.Room
{
    public class UpdateRoomDto
    {
        public int ID { get; set; }
        public int Price { get; set; }
        public RoomStatus Status { get; set; }
    }
}
