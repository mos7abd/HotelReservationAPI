namespace HotelReservationAPI.Dtos.Pictures
{
    public record GetPictureRoomIdDto
    {
        public int RoomId { get; set; }
        public List<PicturesDto> Pictures { get; set; }
    }

}
