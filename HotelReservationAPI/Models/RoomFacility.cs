﻿namespace HotelReservationAPI.Models
{
    public class RoomFacility:BaseModel
    {
        public string Name { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
    }
}
