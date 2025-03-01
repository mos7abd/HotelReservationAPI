﻿namespace HotelReservationAPI.Models
{
    public class Reservation:BaseModel
    {
        public DateTime ChekIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
