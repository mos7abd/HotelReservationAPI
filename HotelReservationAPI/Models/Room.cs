    using HotelReservationAPI.Enum;

namespace HotelReservationAPI.Models
{
    public class Room : BaseModel
    {
        public RoomType Type  { get; set; }
        public int Price { get; set; }
        public int Number { get; set; }
        public RoomStatus Status { get; set; }
<<<<<<< HEAD
        //public ICollection<string>? Pictures { get; set; }
=======
>>>>>>> 9b0a3463997b2dd6045fc1deb71d413ec9892f2e
        public IEnumerable<RoomFacility> RoomFacilities { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Picture> Pictures { get; set; }


    }
}
