namespace HotelReservationAPI.Models
{
    public class Facility:BaseModel
    {
        public string Name { get; set; }
        public IEnumerable<RoomFacility> FacilityRooms { get; set; }

    }
}
