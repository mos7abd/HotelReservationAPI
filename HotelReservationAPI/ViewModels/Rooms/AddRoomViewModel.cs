using HotelReservationAPI.Models;

namespace HotelReservationAPI.ViewModels.Rooms
{
    public class AddRoomViewModel
    {
        public RoomType Type { get; set; }
        public int Price { get; set; }
        public int Number { get; set; }
        public RoomStatus Status { get; set; }
    }
}
