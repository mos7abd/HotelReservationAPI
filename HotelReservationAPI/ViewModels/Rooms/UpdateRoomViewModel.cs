using HotelReservationAPI.Models;

namespace HotelReservationAPI.ViewModels.Rooms
{
    public class UpdateRoomViewModel
    {
        public int ID { get; set; }
        public int Price { get; set; }
        public RoomStatus Status { get; set; }
    }
}
