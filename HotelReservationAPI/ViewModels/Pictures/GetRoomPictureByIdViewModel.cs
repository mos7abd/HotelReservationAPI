namespace HotelReservationAPI.ViewModels.Pictures
{
    public class GetRoomPictureByIdViewModel
    {
        public int RoomId { get; set; }
        public List<PicturesViewModel> Pictures { get; set; }
    }
}
