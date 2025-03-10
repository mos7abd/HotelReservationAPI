namespace HotelReservationAPI.ViewModels.Pictures
{
    public class GetAllRoomPicturesViewModel
    {
        public int RoomId { get; set; }
        public List<PicturesViewModel> Pictures { get; set; }
    }

    public class PicturesViewModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

}
