using FluentValidation;
using HotelReservationAPI.Dtos.Rooms;
using HotelReservationAPI.Enum;
using HotelReservationAPI.Exceptions;

using HotelReservationAPI.Helper;
using HotelReservationAPI.Services;

using HotelReservationAPI.Validators.Rooms;
using HotelReservationAPI.ViewModels;
using HotelReservationAPI.ViewModels.Rooms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HotelReservationAPI.Helper.PagedListQueryableExtensions;

namespace HotelReservationAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoomController : ControllerBase
    {

        private readonly RoomService _roomService;
        private readonly ReservationService _reservationService;
        private readonly IValidator<AddRoomViewModel> _AddRoomViewModelValidator;
        private readonly IValidator<UpdateRoomViewModel> _UpdateRoomViewModelValidator;
        public RoomController()
        {
            _roomService = new RoomService();
            _reservationService = new ReservationService();
            _AddRoomViewModelValidator = new AddRoomViewModelValidator();
            _UpdateRoomViewModelValidator = new UpdateRoomViewModelValidators();
        }
        [HttpGet("GetAll")]
        public async Task<ResponseViewModel<PagedList<GetAllRoomViewModel>>> GetAllAvaliabiltyRoom(int page, int pageSize)

        {
            if (page < 1 || pageSize < 1)
            {
                return ResponseViewModel<PagedList<GetAllRoomViewModel>>.Failure(ErrorCode.BadRequest, "Page and PageSize must be greater than 0");
            }
            var rooms = await _roomService.GetAllAvailableRooms()
                .Project<GetAllRoomViewModel>().ToPagedListAsync(page, pageSize);


            return ResponseViewModel<PagedList<GetAllRoomViewModel>>.Sucess(rooms);

        }
        [HttpGet("{id}")]
        public async Task<ResponseViewModel<GetRoomByIdViewModel>> GetRoomById(int id)
        {

            if (id < 1)
            {
                return ResponseViewModel<GetRoomByIdViewModel>.Failure(ErrorCode.BadRequest, "Id must be greater than 0");
            }
            var room = await _roomService.GetRoomByIdAsync(id);
            if (room is null)
            {
                return ResponseViewModel<GetRoomByIdViewModel>.Failure(ErrorCode.RoomNotFound, "Room not found");
            }
            return ResponseViewModel<GetRoomByIdViewModel>.Sucess(room.Map<GetRoomByIdViewModel>());

        }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> Add(AddRoomViewModel addRoomViewModel)
        {
            var validationResult = _AddRoomViewModelValidator.Validate(addRoomViewModel);
            if (validationResult.IsValid is false)
            {
                throw new RequstValidationException(validationResult);
            }
            var newRoomDto = addRoomViewModel.Map<AddRoomDto>();
            var newRoomId = await _roomService.AddAsync(newRoomDto);

            if (newRoomId == 0)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.InternalServerError, "The room not added");
            }
            return ResponseViewModel<bool>.Sucess(true);
        }
        [HttpPut]
        public async Task<ResponseViewModel<bool>> Update(UpdateRoomViewModel updateRoomViewModel)
        {
            var validationResult = _UpdateRoomViewModelValidator.Validate(updateRoomViewModel);

            if (validationResult.IsValid is false)
            {
                throw new RequstValidationException(validationResult);
            }
            var IsRoomExist = await _roomService.IsRoomExistAsync(updateRoomViewModel.ID);
            if (!IsRoomExist)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.RoomNotFound, "Room not found");
            }

            var updateRoomDto = updateRoomViewModel.Map<UpdateRoomDto>();
            _roomService.Update(updateRoomDto);


            return ResponseViewModel<bool>.Sucess(true);

            //return new SuccessResponseViewModel<bool>(true);
        }
        [HttpDelete]
        public async Task<ResponseViewModel<bool>> Delete(int id)
        {
            if (id < 1)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.BadRequest, "Id must be greater than 0");
            }
            var IsRoomExist = await _roomService.IsRoomExistAsync(id);
            if (!IsRoomExist)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.RoomNotFound, "Room not found");
            }
            // check if the room is reserved in the current data 
            var isRoomReserved = await _reservationService.IsRoomReservedAsync(id, DateTime.UtcNow, DateTime.UtcNow);
            if (isRoomReserved)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.RoomReserved, "Room is reserved");
            }

            _roomService.Delete(id);
            return ResponseViewModel<bool>.Sucess(true);

        }



    }


}
