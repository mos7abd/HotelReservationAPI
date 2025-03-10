namespace HotelReservationAPI.Dtos.Pictures
{
    public record UpdatePictureRoomDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
