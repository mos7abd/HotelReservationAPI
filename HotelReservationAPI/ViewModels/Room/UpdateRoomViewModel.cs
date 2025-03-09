using HotelReservationAPI.Enum;

namespace HotelReservationAPI.ViewModels.Room
{
    public class UpdateRoomViewModel
    {
        public int ID { get; set; }
        public int Price { get; set; }
        public RoomStatus Status { get; set; }
    }
}
