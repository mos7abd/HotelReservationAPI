using HotelReservationAPI.Enum;

namespace HotelReservationAPI.ViewModels.Room
{
    public class AddRoomViewModel
    {
        public RoomType Type { get; set; }
        public int Price { get; set; }
        public int Number { get; set; }
        public RoomStatus Status { get; set; }
        //public ICollection<string> Pictuers { get; set; }
    }
}
