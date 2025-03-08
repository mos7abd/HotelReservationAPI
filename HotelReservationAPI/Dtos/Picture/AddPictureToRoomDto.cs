namespace HotelReservationAPI.Dtos.Picture
{
    public class AddPictureToRoomDto
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
