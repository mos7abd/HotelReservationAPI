using AutoMapper.QueryableExtensions;
using HotelReservationAPI.Dtos.Room;
using HotelReservationAPI.Helper;
using HotelReservationAPI.Models;
using HotelReservationAPI.Services;
using HotelReservationAPI.ViewModels;
using HotelReservationAPI.ViewModels.Room;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        RoomService _roomService;
        CustomerFakeDataService _fakeDataService;
        public RoomController(RoomService roomService, CustomerFakeDataService fakeDataService)
        {
            _roomService= roomService;
            _fakeDataService= fakeDataService;
        }

        [HttpGet]
        public IEnumerable<CutomerViewModel> GetCustomers()
        {
            return _fakeDataService.GetData();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAvaliabiltyRoom()
        {
            var rooms = _roomService.GetAllAvailableRooms()
                .AsQueryable().Project<GetAllRoomViewModel>();

            return Ok(rooms);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = _roomService.GetRoomById(id).Map<GetRoomByIdViewModel>();
            return Ok(room);
        }
        [HttpPost]
        public bool Add(AddRoomViewModel addRoomViewModel)
        {
              var newRoomDto=addRoomViewModel.Map<AddRoomDto>();
            _roomService.Add(newRoomDto);

            return true;
        }
        [HttpPut]
        public bool Update(UpdateRoomViewModel updateRoomViewModel)
        {
           var updateRoomDto= updateRoomViewModel.Map<UpdateRoomDto>();
            _roomService.Update(updateRoomDto);
            return true;
        }
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            _roomService.Delete(id);
            return true;
        }
    }
}
