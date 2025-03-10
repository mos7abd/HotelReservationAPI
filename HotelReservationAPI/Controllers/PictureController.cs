using HotelReservationAPI.Dtos.Pictures;
using HotelReservationAPI.Enum;
using HotelReservationAPI.Helper;
using HotelReservationAPI.Services;
using HotelReservationAPI.ViewModels;
using HotelReservationAPI.ViewModels.Pictures;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        PictureService _pictureService;
        public PictureController()
        {
            _pictureService = new PictureService();
        }

        [HttpGet]
        public async Task<ResponseViewModel<GetAllRoomPicturesViewModel>> GetAllRoomPicture(int roomId)
        {
            var roomPicture = _pictureService.GetAllRoomPictures(roomId)
                .Map<GetAllRoomPicturesViewModel>();

            return ResponseViewModel<GetAllRoomPicturesViewModel>.Success(roomPicture);
        }
        [HttpGet]
        public async Task<ResponseViewModel<GetRoomPictureByIdViewModel>> GetPictureById(int id)
        {
            var picture = _pictureService.GetPictureById(id).Map<GetRoomPictureByIdViewModel>();
            return ResponseViewModel<GetRoomPictureByIdViewModel>.Success(picture);
        }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> Add(AddPictureToRoomViewModel addPictureToRoomViewModel)
        {
            var newpictureDto = addPictureToRoomViewModel.Map<AddPictureToRoomDto>();
            int pictureId = await _pictureService.AddAsync(newpictureDto);
            if (pictureId == 0)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.PictureNotAdded, "Picture Not Added");
            }
            return ResponseViewModel<bool>.Success(true);
        }

        [HttpPut]
        public async Task<ResponseViewModel<bool>> Update(UpdatePictureRoomViewModel updatePictureRoomViewModel)
        {
            var updatePictureDto = updatePictureRoomViewModel.Map<UpdatePictureRoomDto>();
            _pictureService.Update(updatePictureDto);
            return ResponseViewModel<bool>.Success(true);
        }

        [HttpDelete]
        public async Task<ResponseViewModel<bool>> Delete(int id)
        {
            _pictureService.Delete(id);
            return ResponseViewModel<bool>.Success(true);
        }
    }
}
