using HotelReservationAPI.Dtos.Picture;
using HotelReservationAPI.Helper;
using HotelReservationAPI.Services;
using HotelReservationAPI.ViewModels;
using HotelReservationAPI.ViewModels.Picture;
using HotelReservationAPI.ViewModels.ResponseViewModell;
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

            return SuccessResponseViewModel<GetAllRoomPicturesViewModel>.Sucess(roomPicture);
        }
        [HttpGet]
        public async Task<ResponseViewModel<GetRoomPictureByIdViewModel>> GetPictureById(int id)
        {
            var picture = _pictureService.GetPictureById(id).Map<GetRoomPictureByIdViewModel>();
            return SuccessResponseViewModel<GetRoomPictureByIdViewModel>.Sucess(picture);
        }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> Add(AddPictureToRoomViewModel addPictureToRoomViewModel)
        {
            var newpictureDto = addPictureToRoomViewModel.Map<AddPictureToRoomDto>();
            _pictureService.Add(newpictureDto);
            return SuccessResponseViewModel<bool>.Sucess(true);
        }

        [HttpPut]
        public async Task<ResponseViewModel<bool>> Update(UpdatePictureRoomViewModel updatePictureRoomViewModel)
        {
            var updatePictureDto = updatePictureRoomViewModel.Map<UpdatePictureRoomDto>();
            _pictureService.Update(updatePictureDto);
            return SuccessResponseViewModel<bool>.Sucess(true);
        }

        [HttpDelete]
        public async Task<ResponseViewModel<bool>> Delete(int id)
        {
            _pictureService.Delete(id);
            return SuccessResponseViewModel<bool>.Sucess(true);
        }
    }
}
