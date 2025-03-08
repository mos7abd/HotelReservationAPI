﻿using HotelReservationAPI.Enum;

namespace HotelReservationAPI.Dtos.Room
{
    public class GetAllRoomDto
    {
        public int ID { get; set; }
        public RoomType Type { get; set; }
        public int Price { get; set; }
        public int Number { get; set; }
        public RoomStatus Status { get; set; }
    }
}
