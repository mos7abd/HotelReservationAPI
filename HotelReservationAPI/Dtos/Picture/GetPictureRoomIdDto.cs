namespace HotelReservationAPI.Dtos.Picture
{
    public class GetPictureRoomIdDto
    {
        public int RoomId { get; set; }
        public List<PicturesDto> Pictures { get; set; }
    }
   
}
