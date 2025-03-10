using HotelReservationAPI.Dtos.Room;
using HotelReservationAPI.Helper;
using HotelReservationAPI.Models;
using HotelReservationAPI.ResponseModels;
using HotelReservationAPI.Services;
using HotelReservationAPI.ViewModels.Room;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        RoomService _roomService;
        StripeService _stripeService; // test
        public RoomController(RoomService roomService, StripeService stripeService) // test
        {
            _roomService = roomService;
            _stripeService = stripeService; // test
        }
        [HttpGet("GetAll")]
        public async Task<ResponseViewModel<IQueryable<GetAllRoomViewModel>>> GetAllAvaliabiltyRoom()
        {
            var rooms = _roomService.GetAllAvailableRooms()
                .AsQueryable().Project<GetAllRoomViewModel>();

            return ResponseViewModel<IQueryable<GetAllRoomViewModel>>.Success(rooms);
        }
        [HttpGet("{id}")]
        public async Task<ResponseViewModel<GetRoomByIdViewModel>> GetRoomById(int id)
        {
            var room = _roomService.GetRoomById(id).Map<GetRoomByIdViewModel>();

            return ResponseViewModel<GetRoomByIdViewModel>.Success(room);
        }
        [HttpPost]
        public ResponseViewModel<bool> Add(AddRoomViewModel addRoomViewModel)
        {
             var newRoomDto=addRoomViewModel.Map<AddRoomDto>();
            _roomService.Add(newRoomDto);
            // after add room create product in stripe immediately 
            _stripeService.CreateProduct(addRoomViewModel.Map<Room>()); // test

            return ResponseViewModel<bool>.Success(true);
        }
        [HttpPut]
        public ResponseViewModel<bool> Update(UpdateRoomViewModel updateRoomViewModel)
        {
           var updateRoomDto= updateRoomViewModel.Map<UpdateRoomDto>();
            _roomService.Update(updateRoomDto);
            return ResponseViewModel<bool>.Success(true);
        }
        [HttpDelete]
        public async Task<ResponseViewModel<bool>> Delete(int id)
        {
            _roomService.Delete(id);
            return ResponseViewModel<bool>.Success(true);
        }
    }
}
