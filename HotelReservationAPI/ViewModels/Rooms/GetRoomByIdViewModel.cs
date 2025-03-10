using HotelReservationAPI.Models;

namespace HotelReservationAPI.ViewModels.Rooms
{
    public class GetRoomByIdViewModel
    {
        public int ID { get; set; }
        public RoomType Type { get; set; }
        public int Price { get; set; }
        public int Number { get; set; }
        public RoomStatus Status { get; set; }
    }
}
