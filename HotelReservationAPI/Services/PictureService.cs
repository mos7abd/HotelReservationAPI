using HotelReservationAPI.Dtos.Picture;
using HotelReservationAPI.Dtos.Room;
using HotelReservationAPI.Enum;
using HotelReservationAPI.Helper;
using HotelReservationAPI.Models;
using HotelReservationAPI.Repositoried;

namespace HotelReservationAPI.Services
{
    public class PictureService
    {
        GeneralRepository<Picture> _roomPicture;
        public PictureService()
        {
            _roomPicture = new GeneralRepository<Picture>();
        }

        public GetAllPicturesRoomDto GetAllRoomPictures(int id)
        {
            var roomPicture = _roomPicture.Get(r => r.RoomId == id);
            return roomPicture.Map<GetAllPicturesRoomDto>();
        }

        public async Task<PicturesDto> GetPictureById(int id)
        {
            var picture = _roomPicture.Get(r => r.ID == id)
                .Project<PicturesDto>().FirstOrDefault();
            return picture;
        }

        public void Add(AddPictureToRoomDto addPictureToRoomDto) 
        {
            var newPictureToDto = addPictureToRoomDto.Map<Picture>();
            _roomPicture.Add(newPictureToDto);
        }
        public void Update(UpdatePictureRoomDto updatePictureRoomDto)
        {
            var updatePicture=updatePictureRoomDto.Map<Picture>();
            _roomPicture.UpdateInclude(updatePicture, nameof(Picture.Name),
                nameof(Picture.Url));
        }
        public void Delete(int id)
        {
            _roomPicture.Delete(id);
        }
    }
}
