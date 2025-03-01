using HotelReservationAPI.Dtos.Room;
using HotelReservationAPI.Enum;
using HotelReservationAPI.Helper;
using HotelReservationAPI.Models;
using HotelReservationAPI.Repositoried;
using HotelReservationAPI.ViewModels.Room;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HotelReservationAPI.Services
{
    public class RoomService
    {
        GeneralRepository<Room> _roomRepo;
        public RoomService()
        {
            _roomRepo=new GeneralRepository<Room>();
        }
        public IEnumerable<GetAllRoomDto> GetAllAvailableRooms()
        {
            var room = _roomRepo.Get(r =>r.Status==RoomStatus.Available);
            return room.Project<GetAllRoomDto>();
        }
        public GetRoomByIdDto GetRoomById(int id)
        {
            var room = _roomRepo.Get(r => r.ID == id)
                .Project<GetRoomByIdDto>().FirstOrDefault();
            return room;

        }

        public void Add(AddRoomDto addRoomDto)
        {
            var newRoom = addRoomDto.Map<Room>();
            _roomRepo.Add(newRoom);
        }
        public void Update(UpdateRoomDto updateRoomDto)
        {
            var updatedRoom = updateRoomDto.Map<Room>();
            _roomRepo.UpdateInclude(updatedRoom,
                nameof(Room.Type), nameof(Room.Price),
                nameof(Room.Number), nameof(Room.Status));
        }
        public void Delete(int Id)
        {
            _roomRepo.Delete(Id);
        }
    }
}
