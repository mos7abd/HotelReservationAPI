namespace HotelReservationAPI.ViewModels.Picture
{
    public class GetRoomPictureByIdViewModel
    {
        public int RoomId { get; set; }
        public List<PicturesViewModel> Pictures { get; set; }
    }
}
