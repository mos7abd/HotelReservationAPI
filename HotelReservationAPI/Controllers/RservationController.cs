using FluentValidation;
using HotelReservationAPI.Dtos.Reservations;
using HotelReservationAPI.Enum;
using HotelReservationAPI.Exceptions;
using HotelReservationAPI.Helper;
using HotelReservationAPI.Models;
using HotelReservationAPI.Repositoried;
using HotelReservationAPI.Services;
using HotelReservationAPI.Validators.Reservations;
using HotelReservationAPI.ViewModels;
using HotelReservationAPI.ViewModels.Reservations;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RservationController : ControllerBase
    {
        private readonly GeneralRepository<Reservation> _reservationRepository;
        private readonly GeneralRepository<Room> _roomRepository;
        private readonly ReservationService _reservationService;
        private readonly RoomService _roomService;
        private readonly IValidator<AddReservationViewModel> _addReservationViewModelValidator;
        private readonly IValidator<UpdateReservationViewModel> _updateReservationViewModelValidator;

        public RservationController()
        {
            _reservationRepository = new GeneralRepository<Reservation>();
            _roomRepository = new GeneralRepository<Room>();
            _reservationService = new ReservationService();
            _roomService = new RoomService();
            _addReservationViewModelValidator = new AddReservationViewModelValidator();
            _updateReservationViewModelValidator = new UpdateReservationViewModelValidator();
        }

        [HttpGet("{id}")]
        public async Task<ResponseViewModel<GetReservationByIdViewModel>> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                return ResponseViewModel<GetReservationByIdViewModel>
                    .Failure(ErrorCode.BadRequest, "Id must be greater than 0");
            }
            var reservationDto = await _reservationService.GetByIdAsync(id);
            if (reservationDto is null)
            {
                return ResponseViewModel<GetReservationByIdViewModel>
                    .Failure(ErrorCode.ReservationNotFound, "This Reservation Not Found ");
            }
            var reservationViewModel = reservationDto.Map<GetReservationByIdViewModel>();
            return ResponseViewModel<GetReservationByIdViewModel>.Sucess(reservationViewModel);
        }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> AddAsync(AddReservationViewModel addReservationViewModel)
        {
            var validationResult = _addReservationViewModelValidator.Validate(addReservationViewModel);

            if (validationResult.IsValid is false)
            {
                throw new RequstValidationException(validationResult);
            }

            var room = await _roomService.GetRoomByIdAsync(addReservationViewModel.RoomId);
            if (room is null)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.RoomNotFound, "Room Not Found");
            }

            if (room.Status != RoomStatus.Available)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.RoomNotAvailable, "Room Not Available");
            }

            var isRoomReserved = await _reservationService
          .IsRoomReservedAsync(addReservationViewModel.RoomId, addReservationViewModel.CheckIn, addReservationViewModel.CheckOut);

            if (isRoomReserved is true)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.RoomAlreadyReserved, "Room Not Available");
            }

            var addReservationDto = addReservationViewModel.Map<AddReservationDto>();
            var newReservationId = await _reservationService.AddAsync(addReservationDto);
            if (newReservationId == 0)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.ReservationNotAdded, "Reservation Not Added");
            }

            return ResponseViewModel<bool>.Sucess(true);
        }


        [HttpPut]
        public async Task<ResponseViewModel<bool>> Update(UpdateReservationViewModel updateReservationViewModel)
        {
            var validationResult = _updateReservationViewModelValidator.Validate(updateReservationViewModel);
            if (validationResult.IsValid is false)
            {
                throw new RequstValidationException(validationResult);
            }
            bool isReservationExists = await _reservationService.IsExistsAsync(updateReservationViewModel.ID);
            if (isReservationExists is false)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.ReservationNotFound, "Reservation Not Found");
            }
            bool isRoomReserved = await _reservationService
                .IsRoomReservedAsync(updateReservationViewModel.RoomId,
                updateReservationViewModel.CheckIn, updateReservationViewModel.CheckOut);

            if (isRoomReserved is true)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.RoomAlreadyReserved, "Room Already Reserved");
            }
            var updateReservationDto = updateReservationViewModel.Map<UpdateReservationDto>();
            _reservationService.Update(updateReservationDto);
            return ResponseViewModel<bool>.Sucess(true);
        }
        [HttpPut]
        public async Task<ResponseViewModel<bool>> CancelAsync(int id)
        {
            if (id <= 0)
            {
                return ResponseViewModel<bool>
                    .Failure(ErrorCode.BadRequest, "Id must be greater thean 0");
            }
            var reservation = await _reservationService.GetByIdAsync(id);
            if (reservation is null)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.ReservationNotFound, "Reservation Not Found");
            }
            if (reservation.Status == ReservationStatus.Canceled)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.ReservationAlreadyCanceled, "Reservation Already Canceled");
            }
            if (reservation.Status == ReservationStatus.Completed)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.ReservationAlreadyCompleted, "Reservation Already Completed");
            }

            bool isCanceled = await _reservationService.CancelAsync(id);
            if (isCanceled is false)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.ReservationNotCanceled, "Reservation Not Canceled");
            }
            return ResponseViewModel<bool>.Sucess(true);
        }



    }
}
