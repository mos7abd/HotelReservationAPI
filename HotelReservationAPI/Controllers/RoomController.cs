using AutoMapper.QueryableExtensions;
using HotelReservationAPI.Dtos.Room;
using HotelReservationAPI.Helper;
using HotelReservationAPI.Services;
using HotelReservationAPI.ViewModels.Room;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        RoomService _roomService;
        public RoomController()
        {
            _roomService=new RoomService();
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
