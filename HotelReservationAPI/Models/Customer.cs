﻿namespace HotelReservationAPI.Models
{
    public class Customer : BaseModel
    {

        public User User { get; set; }
        public int UserId { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
