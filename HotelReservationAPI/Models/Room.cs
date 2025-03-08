using HotelReservationAPI.Enum;

namespace HotelReservationAPI.Models
{
    public class Room : BaseModel
    {
        public RoomType Type  { get; set; }
        public int Price { get; set; }
        public int Number { get; set; }
        public RoomStatus Status { get; set; }
        public IEnumerable<RoomFacility> RoomFacilities { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Picture> Pictures { get; set; }


    }
}
