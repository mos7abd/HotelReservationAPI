namespace HotelReservationAPI.Dtos.Pictures
{
    public record GetAllPicturesRoomDto
    {
        public int RoomId { get; set; }
        public List<PicturesDto> Pictures { get; set; }
    }

    public record PicturesDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
