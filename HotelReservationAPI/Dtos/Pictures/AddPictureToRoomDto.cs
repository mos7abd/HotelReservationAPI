namespace HotelReservationAPI.Dtos.Pictures
{
    public record AddPictureToRoomDto
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
