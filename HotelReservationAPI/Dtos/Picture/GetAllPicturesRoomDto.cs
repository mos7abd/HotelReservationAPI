namespace HotelReservationAPI.Dtos.Picture
{
    public class GetAllPicturesRoomDto
    {
        public int RoomId { get; set; }
        public List<PicturesDto> Pictures { get; set; }
    }

    public class PicturesDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
